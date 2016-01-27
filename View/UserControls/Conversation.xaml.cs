using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using Cimbalino.Phone.Toolkit.Extensions;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using Hoc_tieng_Nhat_cung_Maruko.Controller;
using Hoc_tieng_Nhat_cung_Maruko.Controller.Bot;
using System.Collections.Generic;
using System;
using Hoc_tieng_Nhat_cung_Maruko.Model.Lesson.WordLesson;
using Telerik.Windows.Controls;

namespace Hoc_tieng_Nhat_cung_Maruko.View.UserControls
{
    public partial class Conversation : UserControl
    {
        public static ObservableCollection<ConversationViewMessage> Messages = new ObservableCollection<ConversationViewMessage>();
        Stack<BotQuestion> _listBotQuestion;

        BotQuestion _currentQuestion;
        bool _isAskedQuestion;
        int _numberOfUserAnswer;

        public Conversation()
        {
            InitializeComponent();
            Loaded += Conversation_Loaded;
        }

        void Conversation_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Task initMessageTask = InitMessages();
            initMessageTask.GetAwaiter().OnCompleted(() =>
            {
                ConversationView.ItemsSource = Messages;
                Dispatcher.BeginInvoke(() => ConversationView.BringIntoView(Messages.Last()));
            });
            InitQuestions();
        }

        private void GenerateDefaultMessages()
        {
            if (Messages == null || Messages.Count == 0)
            {
                Messages.AddRange(new ObservableCollection<ConversationViewMessage>
                {
                    new ConversationViewMessage("Chào bạn " + Common.NameOfUser + " nhé...", 
                                      DateTime.Now, ConversationViewMessageType.Incoming),
                    new ConversationViewMessage(Common.NameOfUser + " với Maruko có thể nói chuyện với nhau ở đây.", 
                                      DateTime.Now, ConversationViewMessageType.Incoming),
                    new ConversationViewMessage("Maruko sẽ hỏi " + Common.NameOfUser + " các từ mới tiếng Nhật để giúp bạn ôn lại từ nhé!",
                                      DateTime.Now, ConversationViewMessageType.Incoming),
                    new ConversationViewMessage("Hi vọng Maruko có thể giúp bạn học tiếng Nhật tốt hơn", 
                                      DateTime.Now, ConversationViewMessageType.Incoming),
                    new ConversationViewMessage("頑張ってよ！", 
                                      DateTime.Now, ConversationViewMessageType.Incoming)
                });
            }
        }

        private IEnumerable<ChatMessage> ConvertMessagesToChatMessages(IEnumerable<ConversationViewMessage> messages)
        {
            return messages.Select(message => new ChatMessage(message.Text, message.TimeStamp, message.Type));
        }

        private IEnumerable<ConversationViewMessage> ConvertChatMessagesToMessages(IEnumerable<ChatMessage> messages)
        {
            return messages.Select(message => new ConversationViewMessage(message.Text, message.TimeStamp, message.Type));
        }

        private async Task InitMessages()
        {
            Messages = ConvertChatMessagesToMessages(await XmlSerializationHelper.Load<ObservableCollection<ChatMessage>>("conversationBotUser.xml"))
                       .ToObservableCollection();

            ReduceNumberOfMessages();

            GenerateDefaultMessages(); 
        }

        private static void ReduceNumberOfMessages()
        {
            if (Messages.Count <= 2000) return;
            int noOfSelectedMessage = 0;
            var reducedMessages = new ObservableCollection<ConversationViewMessage>();

            foreach (ConversationViewMessage message in Messages.Reverse().TakeWhile(message => noOfSelectedMessage++ <= 500))
            {
                reducedMessages.Add(message);
            }

            Messages = new ObservableCollection<ConversationViewMessage>(reducedMessages.Reverse());
        }

        private void InitQuestions()
        {
            _listBotQuestion = new Stack<BotQuestion>();

            var getRandomWordsCommand = new SQLiteCommand(SqLiteHelper.SqLiteConnection("Maruko.db3"))
            {
                CommandText = "SELECT * FROM VOCABULARYDB WHERE LESSON <= " + Common.CurrentWordLesson + " ORDER BY RANDOM() LIMIT 100"
            };

            var learntVocabularies = getRandomWordsCommand.ExecuteQuery<VOCABULARYDB>();

            foreach (var item in learntVocabularies)
            {
                var question = new BotQuestion { Question = item.MEANING.Trim(), Answer = item.TERM.Trim() };
                if (item.TERM.Length < 3)
                {
                    question.Hint = "Từ này có " + item.TERM.Length + " kí tự!";
                }
                else
                {
                    for (int i = 0; i < item.TERM.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            question.Hint += "_";
                        }
                        else
                        {
                            question.Hint += item.TERM[i];
                        }
                    }
                }
                _listBotQuestion.Push(question);
            }
        }

        private async Task SerializeMessages()
        {
            await ConvertMessagesToChatMessages(Messages).ToList().Save("conversationBotUser.xml");
        }

        private async void OnSendingMessage(object sender, ConversationViewMessageEventArgs e)
        {
            var senderMessage = e.Message as ConversationViewMessage;

            if (senderMessage != null)
            {
                var userMessage = new ConversationViewMessage(senderMessage.Text, senderMessage.TimeStamp, senderMessage.Type);

                if (string.IsNullOrEmpty(userMessage.Text))
                {
                    return;
                }

                Messages.Add(userMessage);

                string userMessageText = userMessage.Text;

                ConversationViewMessage botAnswerMessage;

                if (Common.CurrentWordLesson == 0)
                {
                    botAnswerMessage = new ConversationViewMessage("Bạn chưa học bài nào :-(", DateTime.Now, ConversationViewMessageType.Incoming);
                }
                else
                {
                    if (_currentQuestion == null || _currentQuestion.IsCorrect)
                    {
                        if (_listBotQuestion.Count == 0) InitQuestions();
                        _currentQuestion = _listBotQuestion.Pop();
                    }

                    var myBot = new Bot(_currentQuestion);
                    _numberOfUserAnswer++;

                    if (_isAskedQuestion == false)
                    {
                        botAnswerMessage = new ConversationViewMessage(myBot.GiveQuestion(userMessageText), DateTime.Now, ConversationViewMessageType.Incoming);
                        _numberOfUserAnswer = 0;
                        _isAskedQuestion = true;
                    }
                    else if (_numberOfUserAnswer < 3)
                    {
                        var botMessage = myBot.AnswerQuestion(userMessageText, _numberOfUserAnswer);

                        var randomRightAnswer = new[]
                        {
                            "Chuẩn quá đi à. ",
                            "Chính xác! ",
                            "Quá đúng! ",
                            "Không thể khác được! ",
                            "Xời, chứ còn gì nữa! ",
                            "Hoàn hảo! ",
                            "Làm sao sai được từ này nhỉ! ",
                            "Khỏi nói! ",
                            "Đúng rồi đấy! ",
                            "Chắc học bài kĩ rồi, đúng quá! "
                        };
                        if (randomRightAnswer.Contains(botMessage))
                        {
                            if (_listBotQuestion.Count == 0) InitQuestions();
                            _currentQuestion = _listBotQuestion.Pop();
                            myBot.botQuestion = _currentQuestion;
                            botMessage += "\n" + myBot.GiveQuestion(userMessageText);
                        }
                        botAnswerMessage = new ConversationViewMessage(botMessage, DateTime.Now, ConversationViewMessageType.Incoming);

                        _isAskedQuestion = true;
                    }
                    else
                    {
                        var botMessage = myBot.AnswerQuestion(userMessageText, _numberOfUserAnswer);

                        if (_listBotQuestion.Count == 0) InitQuestions();
                        _currentQuestion = _listBotQuestion.Pop();
                        myBot.botQuestion = _currentQuestion;
                        botMessage += "\n" + myBot.GiveQuestion(userMessageText);
                        botAnswerMessage = new ConversationViewMessage(botMessage, DateTime.Now, ConversationViewMessageType.Incoming);

                        _isAskedQuestion = true;
                        _numberOfUserAnswer = 0;
                    }
                }

                Messages.Add(botAnswerMessage);
            }

            await SerializeMessages();
        }
    }

    public class ChatMessage
    {
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }

        public ConversationViewMessageType Type { get; set; }

        public ChatMessage()
        {
        }

        public ChatMessage(string text, DateTime timeStamp, ConversationViewMessageType type)
        {
            Text = text;
            TimeStamp = timeStamp;
            Type = type;
        }
    }
}
