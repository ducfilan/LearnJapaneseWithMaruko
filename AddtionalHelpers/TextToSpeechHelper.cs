using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Phone.Speech.Synthesis;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers
{
    public class TextToSpeechHelper
    {
        static SpeechSynthesizer _synth = new SpeechSynthesizer();

        // Handle the button click event.
        public static async void SpeakJapaneseText(string japaneseText)
        {
            try
            {
                var japaneseVoices = new List<VoiceInformation>();
                for (int i = 0; i < InstalledVoices.All.Count; i++)
                {
                    var voiceInformation = InstalledVoices.All[i] as VoiceInformation;
                    if (voiceInformation != null && voiceInformation.Language == "ja-JP")
                    {
                        japaneseVoices.Add(voiceInformation);
                    }
                }

                // Set the voice as identified by the query.
                _synth.SetVoice(japaneseVoices.ElementAt(0));
                await _synth.SpeakTextAsync(japaneseText);
            }
            catch (InvalidOperationException) { }
            catch (Exception)
            {
                MessageBox.Show("Bạn vào \"cài đặt\" (settings) -> \"giọng nói\" (speech) rồi chọn \"Ngôn ngữ giọng nói\" (Speech language) là \"日本語\" nhé!", "Chưa có giọng đọc", MessageBoxButton.OK);
            }
        }
    }
}
