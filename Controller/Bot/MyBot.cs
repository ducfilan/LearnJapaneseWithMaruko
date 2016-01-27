using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers;
using System.Collections.Generic;

namespace Hoc_tieng_Nhat_cung_Maruko.Controller.Bot
{
    public class Bot
    {
        public string botName = "Maruko";
        public string userName = Common.NameOfUser;
        public BotQuestion botQuestion { set; get; }
        public MyDictionary myDictionary;

        public Bot(BotQuestion botQuestion)
        {
            this.botQuestion = botQuestion;
            this.myDictionary = new MyDictionary(this.botName, Common.NameOfUser);
        }
        /*
        public string Respond(string inputSentence)
        {
            try
            {
                if (IsGreeting(inputSentence))
                {
                    var respondGreetings = new[]
                    {
                        "Xin chào " + Common.NameOfUser + " nha. Gọi gì Maruko thế?",
                        "Nhok đây " + Common.NameOfUser + " ơi",
                        Common.NameOfUser + " gọi là nhóc có mặt liền nè.",
                        "Muốn nói chuyện với Maruko hả " + Common.NameOfUser + "?",
                        "Hôm nay không đi chơi hả mà có thời gian nói chuyện với nhok thế này?"
                    };

                    return respondGreetings[new Random().Next(respondGreetings.Count())];
                }

                var respondSentence = Process(inputSentence);
                return respondSentence;
            }
            catch (Exception e)
            {
                string respondSentence = "Oaa, xin lỗi " + this.userName + " nha. Xuất hiện từ không có trong từ điển của " + this.botName + ". " + this.userName + " hãy liên lạc với admin để được trợ giúp nhé.";
                return respondSentence;
            }

        }
        */
        public string GiveQuestion(string inputSentence)
        {
            try
            {
                var respondSentence = "";
                if (IsGreeting(inputSentence))
                {
                    var respondGreetings = new[]
                    {
                        "Xin chào " + Common.NameOfUser + " nha. Mình luyện tập từ mới nhé? ",
                        "Nhok đây " + Common.NameOfUser + " ơi, học từ mới nào! ",
                        Common.NameOfUser + " đã trở lại, học từ mới với mình nào. ",
                    };

                    respondSentence = respondGreetings[new Random().Next(respondGreetings.Count())];
                }

                respondSentence += ProcessQuestion(inputSentence);
                return respondSentence;
            }
            catch (Exception e)
            {
                string respondSentence = "Oaa, xin lỗi " + this.userName + " nha. Xuất hiện từ không có trong từ điển của " + this.botName + ". " + this.userName + " hãy liên lạc với admin để được trợ giúp nhé.";
                return respondSentence;
            }

        }
        private string RemoveDuplicateChars(string input)
        {
            return new string(input.ToCharArray().Distinct().ToArray());
        }

        private bool IsGreeting(string input)
        {
            input = input.ToLower().Trim();
            VietnameseSignsHelper.RemoveSigns(ref input);
            input = RemoveDuplicateChars(input);
            /*
            var shortGreetings = new[]
            {
                "maruko",
                "bot",
                "nhok",
                "nhoc",
                "chao",
                "ne",
                "nay",
                "hey",
                "e",
                "em",
                "cau",
                "ban",
                "ei",
                "eh",
                "a",
                "i"
            };
            
            if ((from shortGreeting in shortGreetings where shortGreeting.Equals(input) select shortGreeting).Any())
            {
                return true;
            }
            */
            var greetingsList = new[]
            {
                "xin chao",

                "chao ban",
                "chao bot",
                "chao maruko",
                "hi",
                "hilu",
                "helo",
                "he lo",
                "bot oi",
                "bot a",
                "bot ui",
                "bot ne",
                "bot nay",

                "nhok oi",
                "nhok a",
                "nhok ui",
                "nhok ne",
                "nhok nay",

                "nhoc oi",
                "nhoc a",
                "nhoc ui",
                "nhoc ne",
                "nhoc nay",
                
                "maruko oi",
                "maruko a",
                "maruko ui",
                "maruko ne",
                "maruko nay",

                "ui nhoc",
                "ui nhok",
                "ui bot",
                "ui ban",
                "ui maruko",
                
                "a nhoc",
                "a nhok",
                "a bot",
                "a ban",
                "a maruko",

                "oi nhoc",
                "oi nhok",
                "oi bot",
                "oi ban",
                "oi maruko",

                "ne nhoc",
                "ne nhok",
                "ne bot",
                "ne ban",
                "ne maruko",
            };
            return (from greeting in greetingsList where input.Trim().Contains(greeting) select greeting).Any();
        }
        private bool IsAnswerOk(string input)
        {
            var greetingsList = new[]
            {
                "okey",
                "okay",
                "ok",
                "bat dau",
                "choi",
                "start",
                "duoc",
                "thu xem",
                "hoi di",
                "tu nao",
                "tu gi",
                "cai gi",
                "cai j",
                "ukm",
                "uhm",
                "uh",
                "bai nao",

                "chan nhi",
                "okay",

                "ui nhoc",
                "ui nhok",
                "ui bot",
                "ui ban",
                "ui maruko",
                
                "uh nhoc",
                "uh nhok",
                "uh bot",
                "uh ban",
                "uh maruko",

                "ok nhoc",
                "ok nhok",
                "ok bot",
                "ok ban",
                "ok maruko",

                "ukm nhoc",
                "ukm nhok",
                "ukm bot",
                "ukm ban",
                "ukm maruko"
            };
            return (from greeting in greetingsList where RemoveDuplicateChars(input).Contains(RemoveDuplicateChars(greeting)) select greeting).Any();

        }
        public string ProcessQuestion(string inputSentence)
        {
            string respond = "";
            if (IsAnswerOk(inputSentence))
            {
                respond = AskNewQuestion();
            }
            else
            {
                respond += AskNewQuestion();

            }
            return respond;
        }

        public string AskNewQuestion()
        {
            if (botQuestion == null)
            {
                return "Bạn chưa học bài nào cả :-(";
            }
            var respondGreetings = new[]
                    {
                        "Đố "+ Common.NameOfUser +", \"{0}\" tiếng nhật là gì?",
                        "Trả lời thử Maruko xem từ này \"{0}\"",
                        "Để xem nhớ từ không nào: từ này \"{0}\"",
                        "Đố biết nè. Từ này khó này: \"{0}\"",
                        "Có biết từ này không " + Common.NameOfUser + " ơi: \"{0}\""
                    };

            string question = string.Format(respondGreetings[new Random().Next(respondGreetings.Count())], botQuestion.Question);
            return question;
        }
        public string AnswerQuestion(string inputSentence, int numberOfAnswer)
        {
            string respond;
            inputSentence = WordHelper.RemoveSpecialCharacters(inputSentence);

            if (Regex.IsMatch(inputSentence, @"[\w-]+"))
            {
                inputSentence = inputSentence.Replace("-", "").All(char.IsUpper)
                    ? WordHelper.Convert(inputSentence, WordHelper.Mode.Katakana)
                    : WordHelper.Convert(inputSentence, WordHelper.Mode.Hiragana);
            }

            if (inputSentence.Contains(WordHelper.RemoveSpecialCharacters(botQuestion.Answer)))
            {
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

                respond = randomRightAnswer[new Random().Next(randomRightAnswer.Length - 1)];
            }
            else
            {
                respond = HintQuestion(numberOfAnswer);
            }
            return respond;
        }

        public string HintQuestion(int numberOfAnswer)
        {
            string respond;
            if (numberOfAnswer < 2)
            {
                respond = "Sai rồi, thử lại đi ";
            }
            else
                if (numberOfAnswer == 2)
                {
                    respond = "Maruko gợi nè: " + this.botQuestion.Hint;
                }
                else
                {
                    var sadMoods = new[]
                    {
                        "Buồn nhỉ",
                        "Sai mới buồn chứ",
                        "Chán thật đó",
                        "Sao sai được thế",
                        "Sao đã quên rồi à",
                        "Nhớ học lại từ này đi ha",
                        "Quên nhanh ghê ha",
                        "Giờ nhớ đi nghe, hum khác tui hỏi lại",
                        "Thôi chắc không nhớ rùi",
                        "Từ này có khó lắm đâu mà",
                        "Dễ thế mà không biết. Gà thía hehee"
                    };

                    respond = "Ayzaa. " + sadMoods[new Random().Next(sadMoods.Length - 1)] + ". Đáp án là: " + botQuestion.Answer;
                }

            return respond;
        }
        /*
        public string Process(string inputSentence)
        {
            string corePart = inputSentence;

            String respond = this.RespondNotUnderstand();

            #region Xử lí với câu yêu cầu thực hiện chứng năng

            #region Xử lí phần đầu câu
            foreach (Word loiNhoVaDauCau in myDictionary.loiNhoVaDauCau)
            {
                if (WordUtility.StartsWith(corePart, loiNhoVaDauCau))
                {
                    corePart = WordUtility.RemoveStartWords(corePart, loiNhoVaDauCau);
                }
            }
            myDictionary.loiNhoVaDauCau.Reset();

            foreach (Word loiNhanCuoiCau in myDictionary.loiNhanCuoiCau)
            {
                if (WordUtility.EndsWith(corePart, loiNhanCuoiCau))
                {
                    corePart = WordUtility.RemoveEndWords(corePart, loiNhanCuoiCau);
                }
            }
            myDictionary.loiNhoVaDauCau.Reset();

            #endregion

            #region Xu li core

            if (corePart.Equals(String.Empty))
            {
                respond = "Okieee! " + botName + " rất vui khi được giúp đỡ bạn! :\"> ";
                return respond;
            }

            if (WordUtility.StartsWith(corePart, myDictionary.dongTuChiHanhDong.GetWordById((int)DongTuChiHanhDong.giaiNghia)))
            {
                corePart = corePart.Trim();
                var corePartBackup = corePart;
                corePart = WordUtility.RemoveStartWords(corePart, myDictionary.dongTuChiHanhDong.GetWordById((int)DongTuChiHanhDong.giaiNghia)).Trim();

                if (WordUtility.StartsWith(corePart, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.tu)))
                {
                    corePart = WordUtility.RemoveStartWords(corePart, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.tu));

                    string partern = "([\"\'])(?:(?=(\\\\?))\\2.)*?\\1";
                    Regex regex = new Regex(partern, RegexOptions.IgnoreCase);

                    var match = regex.Match(corePart);

                    if (match.Success)
                    {
                        corePart = match.Value;
                    }

                    corePart = WordUtility.RemoveMarks(corePart);
                    corePart = WordHelper.Convert(corePart, WordHelper.Mode.Hiragana);
                    var firstOrDefault = (from jvDictWord in Common.JvDictWords
                                          where jvDictWord.Term.Equals(corePart)
                                          select jvDictWord).FirstOrDefault();
                    if (firstOrDefault != null)
                    {
                        string meaning = firstOrDefault.Definitions.First().Meaning;

                        respond = "Bạn muốn mình giải nghĩa từ " + corePart + " à? Nghĩa của từ đó là: " + meaning;
                    }

                    return respond;
                }

                if (WordUtility.StartsWith(corePartBackup, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.cumTu)))
                {
                    corePartBackup = WordUtility.RemoveStartWords(corePartBackup, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.cumTu));

                    string partern = "([\"\'])(?:(?=(\\\\?))\\2.)*?\\1";
                    Regex regex = new Regex(partern, RegexOptions.IgnoreCase);

                    var match = regex.Match(corePartBackup);

                    if (match.Success)
                    {
                        corePartBackup = match.Value;
                    }

                    corePartBackup = WordUtility.RemoveMarks(corePartBackup);
                    corePartBackup = WordHelper.Convert(corePartBackup, WordHelper.Mode.Hiragana);

                    var firstOrDefault = (from jvDictWord in Common.JvDictWords
                                          where jvDictWord.Term.Equals(corePartBackup)
                                          select jvDictWord).FirstOrDefault();
                    if (firstOrDefault != null)
                    {
                        string meaning = firstOrDefault.Definitions.First().Meaning;

                        respond = "Bạn muốn mình giải nghĩa từ " + corePartBackup + " à? Nghĩa của từ đó là: " + meaning;
                    }
                    return respond;
                }


                corePartBackup = WordUtility.RemoveMarks(corePartBackup);
                corePartBackup = WordHelper.Convert(corePartBackup, WordHelper.Mode.Hiragana);
                var firstOrDefaultx = (from jvDictWord in Common.JvDictWords
                                       where jvDictWord.Term.Equals(corePartBackup)
                                       select jvDictWord).FirstOrDefault();
                if (firstOrDefaultx != null)
                {
                    string meaning = firstOrDefaultx.Definitions.First().Meaning;

                    respond = "Bạn muốn mình giải nghĩa từ " + corePartBackup + " à? Nghĩa của từ đó là: " + meaning;
                }
                return respond;
            }

            if (WordUtility.StartsWith(corePart, myDictionary.dongTuChiHanhDong.GetWordById((int)DongTuChiHanhDong.giaiThich)))
            {
                corePart = WordUtility.RemoveStartWords(corePart, myDictionary.dongTuChiHanhDong.GetWordById((int)DongTuChiHanhDong.giaiThich));
                corePart = corePart.Trim();

                if (WordUtility.StartsWith(corePart, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.tu)))
                {
                    corePart = WordUtility.RemoveStartWords(corePart, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.tu));
                    string partern = "([\"\'])(?:(?=(\\\\?))\\2.)*?\\1";
                    Regex regex = new Regex(partern, RegexOptions.IgnoreCase);

                    var match = regex.Match(corePart);

                    if (match.Success)
                    {
                        corePart = match.Value;
                    }
                    corePart = WordUtility.RemoveMarks(corePart);
                    corePart = WordHelper.Convert(corePart, WordHelper.Mode.Hiragana);
                    var firstOrDefault = (from jvDictWord in Common.JvDictWords
                                          where jvDictWord.Term.Equals(corePart)
                                          select jvDictWord).FirstOrDefault();
                    if (firstOrDefault != null)
                    {
                        string meaning = firstOrDefault.Definitions.First().Meaning;

                        respond = "Bạn muốn mình giải nghĩa từ " + corePart + " à? Nghĩa của từ đó là: " + meaning;
                    }
                    return respond;
                }

                if (WordUtility.StartsWith(corePart, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.cumTu)))
                {
                    corePart = WordUtility.RemoveStartWords(corePart, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.cumTu));
                    string partern = "([\"\'])(?:(?=(\\\\?))\\2.)*?\\1";
                    Regex regex = new Regex(partern, RegexOptions.IgnoreCase);

                    var match = regex.Match(corePart);

                    if (match.Success)
                    {
                        corePart = match.Value;
                    }
                    corePart = WordUtility.RemoveMarks(corePart);
                    corePart = WordHelper.Convert(corePart, WordHelper.Mode.Hiragana);
                    var firstOrDefault = (from jvDictWord in Common.JvDictWords
                                          where jvDictWord.Term.Equals(corePart)
                                          select jvDictWord).FirstOrDefault();
                    if (firstOrDefault != null)
                    {
                        string meaning = firstOrDefault.Definitions.First().Meaning;

                        respond = "Bạn muốn mình giải nghĩa từ " + corePart + " à? Nghĩa của từ đó là: " + meaning;
                    }
                    return respond;
                }

                string meaningEnd = "";

                string parternx = "([\"\'])(?:(?=(\\\\?))\\2.)*?\\1";
                Regex regexx = new Regex(parternx, RegexOptions.IgnoreCase);

                var matchx = regexx.Match(corePart);

                if (matchx.Success)
                {
                    corePart = matchx.Value;
                }
                corePart = WordHelper.Convert(corePart, WordHelper.Mode.Hiragana);
                var firstOrDefaultx = (from jvDictWord in Common.JvDictWords
                                       where jvDictWord.Term.Equals(corePart)
                                       select jvDictWord).FirstOrDefault();
                if (firstOrDefaultx != null)
                {
                    string meaning = firstOrDefaultx.Definitions.First().Meaning;

                    respond = "Bạn muốn mình giải nghĩa từ " + corePart + " à? Nghĩa của từ đó là: " + meaningEnd;
                }

                return respond;
            }

            if (WordUtility.StartsWith(corePart, myDictionary.dongTuChiHanhDong.GetWordById((int)DongTuChiHanhDong.tra)))
            {
                corePart = WordUtility.RemoveStartWords(corePart, myDictionary.dongTuChiHanhDong.GetWordById((int)DongTuChiHanhDong.tra));
                corePart = corePart.Trim();

                if (WordUtility.StartsWith(corePart, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.tu)))
                {
                    corePart = WordUtility.RemoveStartWords(corePart, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.tu));
                    string partern = "([\"\'])(?:(?=(\\\\?))\\2.)*?\\1";
                    Regex regex = new Regex(partern, RegexOptions.IgnoreCase);

                    var match = regex.Match(corePart);

                    if (match.Success)
                    {
                        corePart = match.Value;
                    }
                    corePart = WordUtility.RemoveMarks(corePart);
                    corePart = WordHelper.Convert(corePart, WordHelper.Mode.Hiragana);
                    var firstOrDefault = (from jvDictWord in Common.JvDictWords
                                          where jvDictWord.Term.Equals(corePart)
                                          select jvDictWord).FirstOrDefault();
                    if (firstOrDefault != null)
                    {
                        string meaning = firstOrDefault.Definitions.First().Meaning;

                        respond = "Bạn muốn mình giải nghĩa từ " + corePart + " à? Nghĩa của từ đó là: " + meaning;
                    }
                    return respond;
                }

                if (WordUtility.StartsWith(corePart, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.cumTu)))
                {
                    corePart = WordUtility.RemoveStartWords(corePart, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.cumTu));
                    string partern = "([\"\'])(?:(?=(\\\\?))\\2.)*?\\1";
                    Regex regex = new Regex(partern, RegexOptions.IgnoreCase);

                    var match = regex.Match(corePart);

                    if (match.Success)
                    {
                        corePart = match.Value;
                    }
                    corePart = WordUtility.RemoveMarks(corePart);
                    corePart = WordHelper.Convert(corePart, WordHelper.Mode.Hiragana);
                    var firstOrDefault = (from jvDictWord in Common.JvDictWords
                                          where jvDictWord.Term.Equals(corePart)
                                          select jvDictWord).FirstOrDefault();
                    if (firstOrDefault != null)
                    {
                        string meaning = firstOrDefault.Definitions.First().Meaning;

                        respond = "Bạn muốn mình giải nghĩa từ " + corePart + " à? Nghĩa của từ đó là: " + meaning;
                    }
                    return respond;
                }


                string meaningEnd = "";
                string parternx = "([\"\'])(?:(?=(\\\\?))\\2.)*?\\1";
                Regex regexx = new Regex(parternx, RegexOptions.IgnoreCase);

                var matchx = regexx.Match(corePart);

                if (matchx.Success)
                {
                    corePart = matchx.Value;
                }
                corePart = WordHelper.Convert(corePart, WordHelper.Mode.Hiragana);
                var firstOrDefaultx = (from jvDictWord in Common.JvDictWords
                                       where jvDictWord.Term.Equals(corePart)
                                       select jvDictWord).FirstOrDefault();
                if (firstOrDefaultx != null)
                {
                    meaningEnd = firstOrDefaultx.Definitions.First().Meaning;

                    respond = "Bạn muốn mình giải nghĩa từ " + corePart + " à? Nghĩa của từ đó là: " + meaningEnd;
                }
                return respond;
            }

            if (WordUtility.StartsWith(corePart, myDictionary.dongTuChiHanhDong.GetWordById((int)DongTuChiHanhDong.hat)))
            {
                corePart = WordUtility.RemoveStartWords(corePart, myDictionary.dongTuChiHanhDong.GetWordById((int)DongTuChiHanhDong.hat));
                corePart = corePart.Trim();

                if (corePart.Equals(String.Empty))
                {
                    respond = "Hát á? " + botName + " hát dở ẹc à :\">";
                    return respond;
                }

                if (WordUtility.StartsWith(corePart, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.baiHat)))
                {
                    corePart = WordUtility.RemoveStartWords(corePart, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.baiHat));

                    corePart = WordUtility.RemoveMarks(corePart);
                    //TODO: Check if bot can sing this song
                    if (true)
                    {
                        respond = "Uiii, " + botName + " không biết bài đó. Để sau tập rùi hát cho " + userName + " nghe nha ^^";
                        return respond;
                    }
                    else
                    {
                        //TODO: Sing the song
                    }
                }

                if (WordUtility.StartsWith(corePart, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.bai)))
                {
                    corePart = WordUtility.RemoveStartWords(corePart, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.bai));

                    corePart = WordUtility.RemoveMarks(corePart);
                    //TODO: Check if bot can sing this song
                    if (true)
                    {
                        respond = "Uiii, " + botName + " không biết bài đó. Để sau tập rùi hát cho " + userName + " nghe nha ^^";
                        return respond;
                    }
                    else
                    {
                        //TODO: Sing the song
                    }
                }

            }

            if (WordUtility.StartsWith(corePart, myDictionary.dongTuChiHanhDong.GetWordById((int)DongTuChiHanhDong.dich)))
            {
                corePart = WordUtility.RemoveStartWords(corePart, myDictionary.dongTuChiHanhDong.GetWordById((int)DongTuChiHanhDong.dich));
                corePart = corePart.Trim();

                if (corePart.Equals(String.Empty))
                {
                    respond = "Dịch á? " + botName + " chỉ biết dịch giữa tiếng Nhật và tiếng Việt thuiii :\">";
                    return respond;
                }

                if (WordUtility.StartsWith(corePart, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.tu)))
                {
                    corePart = WordUtility.RemoveStartWords(corePart, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.tu));

                    corePart = WordUtility.RemoveMarks(corePart);
                    //TODO: Get the meaning of word here
                    string meaning = "";

                    respond = "Bạn muốn mình dịch từ \"" + corePart + "\" à? Ý nghĩa của từ đó là: " + meaning;
                    return respond;
                }

                if (WordUtility.StartsWith(corePart, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.cumTu)))
                {
                    corePart = WordUtility.RemoveStartWords(corePart, myDictionary.danhTuChiSuVat.GetWordById((int)DanhTuChiSuVat.cumTu));

                    corePart = WordUtility.RemoveMarks(corePart);
                    corePart = WordHelper.Convert(corePart, WordHelper.Mode.Hiragana);
                    var firstOrDefault = (from jvDictWord in Common.JvDictWords
                                          where jvDictWord.Term.Equals(corePart)
                                          select jvDictWord).FirstOrDefault();
                    if (firstOrDefault != null)
                    {
                        string meaning = firstOrDefault.Definitions.First().Meaning;

                        respond = "Bạn muốn mình giải nghĩa từ " + corePart + " à? Nghĩa của từ đó là: " + meaning;
                    }
                    return respond;
                }

                //TODO: Get the meaning of word here
                string meaningEnd = "";
                var firstOrDefaultx = (from jvDictWord in Common.JvDictWords
                                       where jvDictWord.Term.Equals(corePart)
                                       select jvDictWord).FirstOrDefault();
                if (firstOrDefaultx != null)
                {
                    meaningEnd = firstOrDefaultx.Definitions.First().Meaning;

                    respond = "Bạn muốn mình giải nghĩa từ " + corePart + " à? Nghĩa của từ đó là: " + meaningEnd;
                }
                return respond;
            }

            //TODO: Sẽ bổ sung phần xử lí với các động từ khác

            #endregion

            #endregion

            #region Xử lí câu tán gẫu

            //Get original input
            corePart = inputSentence;

            //Xử lí câu kiểu như: Tôi buồn

            //Remove words: Đôi khi, thỉnh thoảng

            foreach (Word trangTuChiTanSuatDiTruocDTNX in myDictionary.trangTuChiTanSuatDiTruocDTNX)
            {
                if (WordUtility.StartsWith(corePart, trangTuChiTanSuatDiTruocDTNX))
                {
                    corePart = WordUtility.RemoveStartWords(corePart, trangTuChiTanSuatDiTruocDTNX);
                }
            }

            //Remove words: Tôi, mình, tớ...
            foreach (Word daiTuNhanXungNgoiThuNhat in myDictionary.daiTuNhanXungNgoiThuNhat)
            {
                if (WordUtility.StartsWith(corePart, daiTuNhanXungNgoiThuNhat))
                {
                    corePart = WordUtility.RemoveStartWords(corePart, daiTuNhanXungNgoiThuNhat);
                }
            }
            myDictionary.daiTuNhanXungNgoiThuNhat.Reset();

            //Remove words: hay, rất hay, luôn

            foreach (Word trangTuChiTanSuatDiSauDTNX in myDictionary.trangTuChiTanSuatDiSauDTNX)
            {
                if (WordUtility.StartsWith(corePart, trangTuChiTanSuatDiSauDTNX))
                {
                    corePart = WordUtility.RemoveStartWords(corePart, trangTuChiTanSuatDiSauDTNX);
                }
            }

            //Remove words: cảm thấy, đang, đang cảm thấy, chợt thấy, thấy
            foreach (Word dongTuDiKemCamXuc in myDictionary.dongTuDiKemCamXuc)
            {
                if (WordUtility.StartsWith(corePart, dongTuDiKemCamXuc))
                {
                    corePart = WordUtility.RemoveStartWords(corePart, dongTuDiKemCamXuc);
                }
            }

            //TODO: Remove words: mình, bản thân

            //Remove words: hơi, hơi hơi, rất

            foreach (Word trangTuChiMucDo in myDictionary.trangTuChiMucDo)
            {
                if (WordUtility.StartsWith(corePart, trangTuChiMucDo))
                {
                    corePart = WordUtility.RemoveStartWords(corePart, trangTuChiMucDo);
                }
            }

            //Xử lí phần còn lại: buồn, vui...

            if (WordUtility.StartsWith(corePart, myDictionary.tinhTuChiDacDiemTuongDoi.GetWordById((int)TinhTuChiDacDiemTuongDoi.beo)))
            {
                corePart = WordUtility.RemoveStartWords(corePart, myDictionary.tinhTuChiDacDiemTuongDoi.GetWordById((int)TinhTuChiDacDiemTuongDoi.beo));

                if (corePart.Equals(String.Empty))
                {
                    respond = "Uiii, béo mới dễ thương :\"> ";
                    return respond;
                }

                if (WordUtility.StartsWith(corePart, myDictionary.tinhThaiTu.GetWordById((int)TinhThaiTu.nhi)))
                {
                    respond = "Đâu có, chỉ hơi hơi à. Mà béo mới dễ thương :\"> ";
                    return respond;

                }

            }

            //TODO: Bổ sung các case khác

            #endregion

            #region Xử lí câu chào hỏi

            //Get original input
            corePart = inputSentence;

            //TODO: TBD 
            #endregion
            return respond;
        }
        */
        public string RespondNotUnderstand()
        {

            Random myRandom = new Random();
            int respondIndex = (int)myRandom.Next(myDictionary.traLoiKhongHieuY.respondSentences.Count);

            return myDictionary.traLoiKhongHieuY.respondSentences[respondIndex].respondVN;

        }
    }
}