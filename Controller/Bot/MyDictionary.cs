namespace Hoc_tieng_Nhat_cung_Maruko.Controller.Bot
{
    public class MyDictionary : Dictionary
    {
        public WordsList loiNhoVaDauCau { get; set; }

        public WordsList loiNhanCuoiCau { get; set; }

        public WordsList dongTuDiKemCamXuc { get; set; }

        public RespondSentenceList traLoiKhongHieuY { get; set; }

        public MyDictionary(string botName, string userName)
            : base(botName, userName)
        {
            Word myWord;

            RespondSentence myRespondSentence;

            #region Step 1. Initialize List loiNhoVaDauCau
            //Init list
            this.loiNhoVaDauCau = new WordsList();
            this.loiNhoVaDauCau.wordType = (int)TuLoai.loiNhoVaDauCau;

            //Add words

            int count = 0;

            //Vì các cụm từ có thể chứa nhau nên phải add các từ dài trước, từ ngắn sau ==> Cần Foreach nhiều lần

            foreach (Word daiTuNhanXungNgoiThuNhat in this.daiTuNhanXungNgoiThuNhat)
            {
                foreach (Word daiTuNhanXungNgoiThuHai in this.daiTuNhanXungNgoiThuHai)
                {
                    count++;
                    myWord = new Word(count, daiTuNhanXungNgoiThuHai.labelNoMark + " co the giup " + daiTuNhanXungNgoiThuNhat.labelNoMark,
                        daiTuNhanXungNgoiThuHai.labelHasMark + " có thể giúp " + daiTuNhanXungNgoiThuNhat.labelHasMark);
                    this.loiNhoVaDauCau.words.Add(myWord);
                }
                this.daiTuNhanXungNgoiThuHai.Reset();
            }
            this.daiTuNhanXungNgoiThuNhat.Reset();


            foreach (Word daiTuNhanXungNgoiThuHai in this.daiTuNhanXungNgoiThuHai)
            {
                count++;
                myWord = new Word(count, daiTuNhanXungNgoiThuHai.labelNoMark + " co the giup",
                    daiTuNhanXungNgoiThuHai.labelHasMark + " có thể giúp");
                this.loiNhoVaDauCau.words.Add(myWord);
            }
            this.daiTuNhanXungNgoiThuHai.Reset();

            foreach (Word daiTuNhanXungNgoiThuHai in this.daiTuNhanXungNgoiThuHai)
            {
                count++;
                myWord = new Word(count, daiTuNhanXungNgoiThuHai.labelNoMark + " co the",
                    daiTuNhanXungNgoiThuHai.labelHasMark + " có thể");
                this.loiNhoVaDauCau.words.Add(myWord);
            }
            this.daiTuNhanXungNgoiThuHai.Reset();

            foreach (Word daiTuNhanXungNgoiThuNhat in this.daiTuNhanXungNgoiThuNhat)
            {
                foreach (Word daiTuNhanXungNgoiThuHai in this.daiTuNhanXungNgoiThuHai)
                {
                    count++;
                    myWord = new Word(count, daiTuNhanXungNgoiThuHai.labelNoMark + " hay giup " + daiTuNhanXungNgoiThuNhat.labelNoMark,
                        daiTuNhanXungNgoiThuHai.labelHasMark + " hãy giúp " + daiTuNhanXungNgoiThuNhat.labelHasMark);
                    this.loiNhoVaDauCau.words.Add(myWord);
                }
                this.daiTuNhanXungNgoiThuHai.Reset();
            }
            this.daiTuNhanXungNgoiThuNhat.Reset();

            foreach (Word daiTuNhanXungNgoiThuNhat in this.daiTuNhanXungNgoiThuNhat)
            {
                count++;
                myWord = new Word(count, "hay giup " + daiTuNhanXungNgoiThuNhat.labelNoMark,
                    "hãy giúp " + daiTuNhanXungNgoiThuNhat.labelHasMark);
                this.loiNhoVaDauCau.words.Add(myWord);
            }
            this.daiTuNhanXungNgoiThuNhat.Reset();

            count++;
            myWord = new Word(count, "hay", "hãy");
            this.loiNhoVaDauCau.words.Add(myWord);

            #endregion

            #region Step 2. Initialize List loiNhanCuoiCau
            //Init list
            this.loiNhanCuoiCau = new WordsList();
            this.loiNhanCuoiCau.wordType = (int)TuLoai.loiNhanCuoiCau;

            myWord = new Word((int)LoiNhanCuoiCau.duocHem, "duoc hem", "được hem");
            this.loiNhanCuoiCau.words.Add(myWord);

            myWord = new Word((int)LoiNhanCuoiCau.duocKhong, "duoc khong", "được không");
            this.loiNhanCuoiCau.words.Add(myWord);

            myWord = new Word((int)LoiNhanCuoiCau.voiNha, "voi nha", "với nha");
            this.loiNhanCuoiCau.words.Add(myWord);

            myWord = new Word((int)LoiNhanCuoiCau.nha, "nha", "nha");
            this.loiNhanCuoiCau.words.Add(myWord);

            myWord = new Word((int)LoiNhanCuoiCau.nhe, "nhe", "nhé");
            this.loiNhanCuoiCau.words.Add(myWord);

            myWord = new Word((int)LoiNhanCuoiCau.khong, "khong", "không");
            this.loiNhanCuoiCau.words.Add(myWord);

            myWord = new Word((int)LoiNhanCuoiCau.voi, "voi", "với");
            this.loiNhanCuoiCau.words.Add(myWord);

            #endregion

            #region Step 3. Initialize List phuTuDiKemCamXuc

            //Init list
            this.dongTuDiKemCamXuc = new WordsList();
            this.dongTuDiKemCamXuc.wordType = (int)TuLoai.dongTuDiKemCamXuc;

            myWord = new Word((int)DongTuDiKemCamXuc.camThay, "cam thay", "cảm thấy");
            this.dongTuDiKemCamXuc.words.Add(myWord);

            myWord = new Word((int)DongTuDiKemCamXuc.chotThay, "chot thay", "chợt thấy");
            this.dongTuDiKemCamXuc.words.Add(myWord);

            myWord = new Word((int)DongTuDiKemCamXuc.dangCamThay, "dang cam thay", "đang cảm thấy");
            this.dongTuDiKemCamXuc.words.Add(myWord);

            myWord = new Word((int)DongTuDiKemCamXuc.dang, "dang", "đang");
            this.dongTuDiKemCamXuc.words.Add(myWord);

            myWord = new Word((int)DongTuDiKemCamXuc.thay, "thay", "thấy");
            this.dongTuDiKemCamXuc.words.Add(myWord);

            #endregion

            #region Step 4. Initialize List traLoiKhongHieuY

            this.traLoiKhongHieuY = new RespondSentenceList();
            this.traLoiKhongHieuY.respondSentenceType = (int)LoaiCauTraLoi.traLoiKhongHieuY;

            myRespondSentence = new RespondSentence(0, "Xin lỗi, " + botName + " không hiểu bạn nói gì :'(", "TBD");
            this.traLoiKhongHieuY.respondSentences.Add(myRespondSentence);

            myRespondSentence = new RespondSentence(1, "Hic hic, " + userName + " nói gì cơ? ~~", "TBD");
            this.traLoiKhongHieuY.respondSentences.Add(myRespondSentence);

            myRespondSentence = new RespondSentence(2, "Hic hic, ý " + userName + " là...? ~~", "TBD");
            this.traLoiKhongHieuY.respondSentences.Add(myRespondSentence);

            myRespondSentence = new RespondSentence(3, "Ui, " + botName + " hem hiểu ý " + userName + " lắm :|", "TBD");
            this.traLoiKhongHieuY.respondSentences.Add(myRespondSentence);

            #endregion
        }
    }
}