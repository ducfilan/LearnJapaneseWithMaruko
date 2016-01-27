namespace Hoc_tieng_Nhat_cung_Maruko.Controller.Bot
{
    public class Dictionary
    {
        public WordsList danhTuChiDonVi { get; set; }
        public WordsList danhTuChiSuVat { get; set; }
        public WordsList dongTuChiTinhThai { get; set; }
        public WordsList dongTuChiHanhDong { get; set; }
        public WordsList tinhTuChiDacDiemTuongDoi { get; set; }
        public WordsList tinhTuChiDacDiemTuyetDoi { get; set; }
        public WordsList soTu { get; set; }
        public WordsList daiTuChiNguoi { get; set; }
        public WordsList daiTuChiSuVat { get; set; }
        public WordsList daiTuDeHoi { get; set; }
        public WordsList luongTu { get; set; }
        public WordsList chiTu { get; set; }
        public WordsList quanHeTu { get; set; }
        public WordsList phoTu { get; set; }
        public WordsList troTu { get; set; }
        public WordsList thanTu { get; set; }
        public WordsList tinhThaiTu { get; set; }

        public WordsList daiTuNhanXungNgoiThuNhat { get; set; }

        public WordsList daiTuNhanXungNgoiThuHai { get; set; }

        public WordsList trangTuChiMucDo { get; set; }

        public WordsList trangTuChiTanSuatDiTruocDTNX { get; set; }

        public WordsList trangTuChiTanSuatDiSauDTNX { get; set; }

        public Dictionary()
        {
            Word myWord;

            #region Step 1. Initialize List danhTuChiDonVi
            //Init list
            this.danhTuChiDonVi = new WordsList();
            this.danhTuChiDonVi.wordType = (int)TuLoai.danhTuChiDonVi;
            //Add words
            myWord = new Word((int)DanhTuChiDonVi.cai, "cai", "cái");
            this.danhTuChiDonVi.words.Add(myWord);

            myWord = new Word((int)DanhTuChiDonVi.can, "can", "cân");
            this.danhTuChiDonVi.words.Add(myWord);

            myWord = new Word((int)DanhTuChiDonVi.chiec, "chiec", "chiếc");
            this.danhTuChiDonVi.words.Add(myWord);

            myWord = new Word((int)DanhTuChiDonVi.dan, "dan", "đàn");
            this.danhTuChiDonVi.words.Add(myWord);

            myWord = new Word((int)DanhTuChiDonVi.doan, "doan", "đoạn");
            this.danhTuChiDonVi.words.Add(myWord);

            myWord = new Word((int)DanhTuChiDonVi.nhom, "nhom", "nhóm");
            this.danhTuChiDonVi.words.Add(myWord);

            myWord = new Word((int)DanhTuChiDonVi.cum, "cum", "cụm");
            this.danhTuChiDonVi.words.Add(myWord);
            #endregion

            #region Step 2. Initialize List danhTuChiSuVat

            //Init list
            this.danhTuChiSuVat = new WordsList();

            this.danhTuChiSuVat.wordType = (int)TuLoai.danhTuChiSuVat;

            //Add words
            myWord = new Word((int)DanhTuChiSuVat.bai, "bai", "bài");
            this.danhTuChiSuVat.words.Add(myWord);

            myWord = new Word((int)DanhTuChiSuVat.baiHat, "bai hat", "bài hát");
            this.danhTuChiSuVat.words.Add(myWord);

            myWord = new Word((int)DanhTuChiSuVat.chuCai, "chu cai", "chữ cái");
            this.danhTuChiSuVat.words.Add(myWord);

            myWord = new Word((int)DanhTuChiSuVat.chucNang, "chuc nang", "chức năng");
            this.danhTuChiSuVat.words.Add(myWord);

            myWord = new Word((int)DanhTuChiSuVat.cumTu, "cum tu", "cụm từ");
            this.danhTuChiSuVat.words.Add(myWord);

            myWord = new Word((int)DanhTuChiSuVat.tieng, "tieng", "tiếng");
            this.danhTuChiSuVat.words.Add(myWord);

            myWord = new Word((int)DanhTuChiSuVat.tinhYeu, "tinh yeu", "tình yêu");
            this.danhTuChiSuVat.words.Add(myWord);

            myWord = new Word((int)DanhTuChiSuVat.tu, "tu", "từ");
            this.danhTuChiSuVat.words.Add(myWord);
            #endregion

            #region Step 3. Initialize List dongTuChiTinhThai

            //Init list
            this.dongTuChiTinhThai = new WordsList();

            this.dongTuChiTinhThai.wordType = (int)TuLoai.danhTuChiSuVat;

            //Add words
            myWord = new Word((int)DongTuChiTinhThai.can, "can", "cần");
            this.dongTuChiTinhThai.words.Add(myWord);

            myWord = new Word((int)DongTuChiTinhThai.canPhai, "can phai", "cần phải");
            this.dongTuChiTinhThai.words.Add(myWord);

            myWord = new Word((int)DongTuChiTinhThai.coThe, "co the", "có thể");
            this.dongTuChiTinhThai.words.Add(myWord);

            myWord = new Word((int)DongTuChiTinhThai.khongNen, "khong nen", "không nên");
            this.dongTuChiTinhThai.words.Add(myWord);

            myWord = new Word((int)DongTuChiTinhThai.khongThe, "khong the", "không thể");
            this.dongTuChiTinhThai.words.Add(myWord);

            myWord = new Word((int)DongTuChiTinhThai.nen, "nen", "nên");
            this.dongTuChiTinhThai.words.Add(myWord);
            #endregion

            #region Step 4. Initialize List dongTuChiHanhDong

            //Init list
            this.dongTuChiHanhDong = new WordsList();

            this.dongTuChiHanhDong.wordType = (int)TuLoai.dongTuChiHanhDong;

            //Add words
            myWord = new Word((int)DongTuChiHanhDong.biet, "biet", "biết");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.camOn, "cam on", "cám ơn");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.cho, "cho", "cho");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.choBiet, "cho biet", "cho biết");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.di, "di", "đi");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.dich, "dich", "dịch");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.doc, "doc", "đọc");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.dung, "dung", "dùng");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.giaiNghia, "giai nghia", "giải nghĩa");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.giaiThich, "giai thich", "giải thích");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.giup, "giup", "giúp");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.giupDo, "giup do", "giúp đỡ");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.hat, "hat", "hát");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.mo, "mo", "mở");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.nghi, "nghi", "nghĩ");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.ngoi, "ngoi", "ngồi");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.noi, "noi", "nói");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.noiChuyen, "noi chuyen", "nói chuyện");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.phatAm, "phat am", "phát âm");
            this.dongTuChiHanhDong.words.Add(myWord);

            myWord = new Word((int)DongTuChiHanhDong.tra, "tra", "tra");
            this.dongTuChiHanhDong.words.Add(myWord);

            #endregion

            #region Step 5. Initialize List tinhTuChiDacDiemTuongDoi

            //Init list
            this.tinhTuChiDacDiemTuongDoi = new WordsList();

            this.tinhTuChiDacDiemTuongDoi.wordType = (int)TuLoai.tinhTuChiDacDiemTuongDoi;

            //Add words
            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.beo, "beo", "béo");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.dep, "dep", "đẹp");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.gay, "gay", "gầy");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.gia, "gia", "già");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.khoe, "khoe", "khỏe");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.ngocNghech, "ngoc nghech", "ngốc nghếch");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.nguNgoc, "ngu ngoc", "ngu ngốc");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.taiCan, "tai can", "tài cán");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.taiGioi, "tai gioi", "tài giỏi");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.thanKinh, "than kinh", "thần kinh");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.thongMinh, "thong minh", "thông minh");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.tot, "tot", "tốt");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.tre, "tre", "trẻ");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.xau, "xau", "xấu");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.xauXi, "xau xi", "xấu xí");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.xinh, "xinh", "xinh");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.xinhDep, "xinh dep", "xinh đẹp");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.buon, "buon", "buồn");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.vui, "vui", "vui");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuongDoi.chan, "chan", "chán");
            this.tinhTuChiDacDiemTuongDoi.words.Add(myWord);

            #endregion

            #region Step 6. Initialize List tinhTuChiDacDiemTuyetDoi

            //Init list
            this.tinhTuChiDacDiemTuyetDoi = new WordsList();

            this.tinhTuChiDacDiemTuyetDoi.wordType = (int)TuLoai.tinhTuChiDacDiemTuyetDoi;

            //Add words
            myWord = new Word((int)TinhTuChiDacDiemTuyetDoi.doLom, "do lom", "đỏ lòm");
            this.tinhTuChiDacDiemTuyetDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuyetDoi.thomPhuc, "thom phuc", "thơm phức");
            this.tinhTuChiDacDiemTuyetDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuyetDoi.trangToat, "trang toat", "trắng toát");
            this.tinhTuChiDacDiemTuyetDoi.words.Add(myWord);

            myWord = new Word((int)TinhTuChiDacDiemTuyetDoi.xanhLe, "xanh le", "xanh lè");
            this.tinhTuChiDacDiemTuyetDoi.words.Add(myWord);
            #endregion

            #region Step 7. Initialize List soTu

            //Init list
            this.soTu = new WordsList();

            this.soTu.wordType = (int)TuLoai.soTu;

            //Add words
            myWord = new Word((int)SoTu.ba, "ba", "ba");
            this.soTu.words.Add(myWord);

            myWord = new Word((int)SoTu.bon, "bon", "bốn");
            this.soTu.words.Add(myWord);

            myWord = new Word((int)SoTu.hai, "hai", "hai");
            this.soTu.words.Add(myWord);

            myWord = new Word((int)SoTu.mot, "mot", "một");
            this.soTu.words.Add(myWord);

            myWord = new Word((int)SoTu.nam, "nam", "năm");
            this.soTu.words.Add(myWord);

            #endregion

            #region Step 8. Initialize List daiTuChiNguoi

            //Init list
            this.daiTuChiNguoi = new WordsList();

            this.daiTuChiNguoi.wordType = (int)TuLoai.daiTuChiNguoi;

            myWord = new Word((int)DaiTuChiNguoi.bonNo, "bon no", "bọn nó");
            this.daiTuChiNguoi.words.Add(myWord);

            myWord = new Word((int)DaiTuChiNguoi.bonTao, "bon tao", "bọn tao");
            this.daiTuChiNguoi.words.Add(myWord);

            myWord = new Word((int)DaiTuChiNguoi.bonTo, "bon to", "bọn tớ");
            this.daiTuChiNguoi.words.Add(myWord);

            myWord = new Word((int)DaiTuChiNguoi.cacBan, "cac ban", "các bạn");
            this.daiTuChiNguoi.words.Add(myWord);

            myWord = new Word((int)DaiTuChiNguoi.cacCau, "cac cau", "các cậu");
            this.daiTuChiNguoi.words.Add(myWord);

            myWord = new Word((int)DaiTuChiNguoi.chungMinh, "chung minh", "chúng mình");
            this.daiTuChiNguoi.words.Add(myWord);

            myWord = new Word((int)DaiTuChiNguoi.chungNo, "chung no", "chúng nó");
            this.daiTuChiNguoi.words.Add(myWord);

            myWord = new Word((int)DaiTuChiNguoi.chungTo, "chung to", "chúng tớ");
            this.daiTuChiNguoi.words.Add(myWord);

            myWord = new Word((int)DaiTuChiNguoi.chungToi, "chung toi", "chúng tôi");
            this.daiTuChiNguoi.words.Add(myWord);

            myWord = new Word((int)DaiTuChiNguoi.han, "han", "hắn");
            this.daiTuChiNguoi.words.Add(myWord);

            myWord = new Word((int)DaiTuChiNguoi.ho, "ho", "họ");
            this.daiTuChiNguoi.words.Add(myWord);

            myWord = new Word((int)DaiTuChiNguoi.minh, "minh", "mình");
            this.daiTuChiNguoi.words.Add(myWord);

            myWord = new Word((int)DaiTuChiNguoi.ta, "ta", "ta");
            this.daiTuChiNguoi.words.Add(myWord);

            myWord = new Word((int)DaiTuChiNguoi.tao, "tao", "tao");
            this.daiTuChiNguoi.words.Add(myWord);

            myWord = new Word((int)DaiTuChiNguoi.to, "to", "tớ");
            this.daiTuChiNguoi.words.Add(myWord);

            myWord = new Word((int)DaiTuChiNguoi.toi, "toi", "tôi");
            this.daiTuChiNguoi.words.Add(myWord);

            myWord = new Word((int)DaiTuChiNguoi.tuiNo, "tui no", "tụi nó");
            this.daiTuChiNguoi.words.Add(myWord);

            myWord = new Word((int)DaiTuChiNguoi.tuiTo, "tui to", "tụi tớ");
            this.daiTuChiNguoi.words.Add(myWord);

            #endregion

            #region Step 9. Initialize List daiTuChiVat

            //Init list
            this.daiTuChiSuVat = new WordsList();

            this.daiTuChiSuVat.wordType = (int)TuLoai.daiTuChiSuVat;

            myWord = new Word((int)DaiTuChiSuVat.chung, "chung", "chúng");
            this.daiTuChiSuVat.words.Add(myWord);

            #endregion

            #region Step 10. Initialize List daiTuDeHoi

            //Init list
            this.daiTuDeHoi = new WordsList();

            this.daiTuDeHoi.wordType = (int)TuLoai.daiTuDeHoi;

            myWord = new Word((int)DaiTuDeHoi.ai, "ai", "ai");
            this.daiTuDeHoi.words.Add(myWord);

            myWord = new Word((int)DaiTuDeHoi.baoNhieu, "bao nhieu", "bao nhiêu");
            this.daiTuDeHoi.words.Add(myWord);

            myWord = new Word((int)DaiTuDeHoi.gi, "gi", "gì");
            this.daiTuDeHoi.words.Add(myWord);

            myWord = new Word((int)DaiTuDeHoi.may, "may", "mấy");
            this.daiTuDeHoi.words.Add(myWord);

            myWord = new Word((int)DaiTuDeHoi.the, "the", "thế");
            this.daiTuDeHoi.words.Add(myWord);
            #endregion

            #region Step 11. Initialize List luongTu

            //Init list
            this.luongTu = new WordsList();

            this.luongTu.wordType = (int)TuLoai.luongTu;

            myWord = new Word((int)LuongTu.ca, "ca", "cả");
            this.luongTu.words.Add(myWord);

            myWord = new Word((int)LuongTu.cac, "cac", "các");
            this.luongTu.words.Add(myWord);

            myWord = new Word((int)LuongTu.moi, "moi", "mỗi");
            this.luongTu.words.Add(myWord);

            myWord = new Word((int)LuongTu.nhung, "nhung", "những");
            this.luongTu.words.Add(myWord);

            myWord = new Word((int)LuongTu.tung, "tung", "từng");
            this.luongTu.words.Add(myWord);

            #endregion

            #region Step 12. Initialize List chiTu

            //Init list
            this.chiTu = new WordsList();

            this.chiTu.wordType = (int)TuLoai.chiTu;

            myWord = new Word((int)ChiTu._do, "do", "đó");
            this.chiTu.words.Add(myWord);

            myWord = new Word((int)ChiTu.ay, "ay", "ấy");
            this.chiTu.words.Add(myWord);

            myWord = new Word((int)ChiTu.kia, "kia", "kia");
            this.chiTu.words.Add(myWord);

            myWord = new Word((int)ChiTu.no, "no", "nọ");
            this.chiTu.words.Add(myWord);

            #endregion

            #region Step 12. Initialize List quanHeTu

            //Init list
            this.quanHeTu = new WordsList();

            this.quanHeTu.wordType = (int)TuLoai.quanHeTu;

            myWord = new Word((int)QuanHeTu.bang, "bang", "bằng");
            this.quanHeTu.words.Add(myWord);

            myWord = new Word((int)QuanHeTu.boiVay, "boi vay", "bởi vậy");
            this.quanHeTu.words.Add(myWord);

            myWord = new Word((int)QuanHeTu.cua, "cua", "của");
            this.quanHeTu.words.Add(myWord);

            myWord = new Word((int)QuanHeTu.doDo, "do do", "do đó");
            this.quanHeTu.words.Add(myWord);

            myWord = new Word((int)QuanHeTu.nen, "nen", "nên");
            this.quanHeTu.words.Add(myWord);

            myWord = new Word((int)QuanHeTu.nhung, "nhung", "nhưng");
            this.quanHeTu.words.Add(myWord);

            myWord = new Word((int)QuanHeTu.o, "o", "ở");
            this.quanHeTu.words.Add(myWord);

            myWord = new Word((int)QuanHeTu.tuy, "tuy", "tuy");
            this.quanHeTu.words.Add(myWord);

            myWord = new Word((int)QuanHeTu.tuyNhien, "tuy nhien", "tuy nhiên");
            this.quanHeTu.words.Add(myWord);

            myWord = new Word((int)QuanHeTu.ve, "ve", "về");
            this.quanHeTu.words.Add(myWord);

            myWord = new Word((int)QuanHeTu.vi, "vi", "vì");
            this.quanHeTu.words.Add(myWord);

            myWord = new Word((int)QuanHeTu.viThe, "vi the", "vì thế");
            this.quanHeTu.words.Add(myWord);

            #endregion

            #region Step 13. Initialize List phoTu

            //Init list
            this.phoTu = new WordsList();

            this.phoTu.wordType = (int)TuLoai.phoTu;

            myWord = new Word((int)PhoTu.cung, "cung", "cũng");
            this.phoTu.words.Add(myWord);

            myWord = new Word((int)PhoTu.da, "da", "đã");
            this.phoTu.words.Add(myWord);

            myWord = new Word((int)PhoTu.rat, "rat", "rất");
            this.phoTu.words.Add(myWord);

            myWord = new Word((int)PhoTu.that, "that", "thật");
            this.phoTu.words.Add(myWord);

            myWord = new Word((int)PhoTu.van, "van", "vẫn");
            this.phoTu.words.Add(myWord);

            myWord = new Word((int)PhoTu.vanChua, "van chua", "vẫn chưa");
            this.phoTu.words.Add(myWord);

            #endregion

            #region Step 14. Initialize List troTu
            //Init list
            this.troTu = new WordsList();

            this.troTu.wordType = (int)TuLoai.troTu;

            myWord = new Word((int)TroTu.ha, "ha", "hả");
            this.troTu.words.Add(myWord);

            myWord = new Word((int)TroTu.ho, "ho", "hở");
            this.troTu.words.Add(myWord);

            myWord = new Word((int)TroTu.thi, "thi", "thì");
            this.troTu.words.Add(myWord);

            #endregion

            #region Step 15. Initialize List thanTu
            //Init list
            this.thanTu = new WordsList();

            this.thanTu.wordType = (int)TuLoai.thanTu;

            myWord = new Word((int)ThanTu.hoi, "hoi", "hỡi");
            this.thanTu.words.Add(myWord);

            myWord = new Word((int)ThanTu.hoiOi, "hoi oi", "hỡi ôi");
            this.thanTu.words.Add(myWord);

            myWord = new Word((int)ThanTu.hoi, "hoi", "hỡi");
            this.thanTu.words.Add(myWord);

            myWord = new Word((int)ThanTu.oi, "oi", "ôi");
            this.thanTu.words.Add(myWord);

            myWord = new Word((int)ThanTu.thanOi, "than oi", "than ôi");
            this.thanTu.words.Add(myWord);

            myWord = new Word((int)ThanTu.troiOi, "troi oi", "trời ơi");
            this.thanTu.words.Add(myWord);

            #endregion

            #region Step 16. Initialize List tinhThaiTu
            //Init list
            this.tinhThaiTu = new WordsList();

            this.tinhThaiTu.wordType = (int)TuLoai.tinhThaiTu;

            myWord = new Word((int)TinhThaiTu.a, "a", "à");
            this.tinhThaiTu.words.Add(myWord);

            myWord = new Word((int)TinhThaiTu.aj, "a", "ạ");
            this.tinhThaiTu.words.Add(myWord);

            myWord = new Word((int)TinhThaiTu.co, "co", "cơ");
            this.tinhThaiTu.words.Add(myWord);

            myWord = new Word((int)TinhThaiTu.day, "day", "đấy");
            this.tinhThaiTu.words.Add(myWord);

            myWord = new Word((int)TinhThaiTu.ma, "ma", "mà");
            this.tinhThaiTu.words.Add(myWord);

            myWord = new Word((int)TinhThaiTu.nao, "nao", "nào");
            this.tinhThaiTu.words.Add(myWord);

            myWord = new Word((int)TinhThaiTu.nhe, "nhe", "nhé");
            this.tinhThaiTu.words.Add(myWord);

            myWord = new Word((int)TinhThaiTu.nhi, "nhi", "nhỉ");
            this.tinhThaiTu.words.Add(myWord);

            myWord = new Word((int)TinhThaiTu.nho, "nho", "nhở");
            this.tinhThaiTu.words.Add(myWord);

            myWord = new Word((int)TinhThaiTu.oi, "oi", "ôi");
            this.tinhThaiTu.words.Add(myWord);

            myWord = new Word((int)TinhThaiTu.thay, "thay", "thay");
            this.tinhThaiTu.words.Add(myWord);

            myWord = new Word((int)TinhThaiTu.thi, "thi", "thì");
            this.tinhThaiTu.words.Add(myWord);

            #endregion

            #region Step 17. Initialize List daiTuNhanXungNgoiThuNhat
            //Init list
            this.daiTuNhanXungNgoiThuNhat = new WordsList();

            this.daiTuNhanXungNgoiThuNhat.wordType = (int)TuLoai.daiTuNhanXungNgoiThuNhat;

            myWord = new Word((int)DaiTuNhanXungNgoiThuNhat.bonTao, "bon tao", "bọn tao");
            this.daiTuNhanXungNgoiThuNhat.words.Add(myWord);

            myWord = new Word((int)DaiTuNhanXungNgoiThuNhat.chungMinh, "chung minh", "chúng mình");
            this.daiTuNhanXungNgoiThuNhat.words.Add(myWord);

            myWord = new Word((int)DaiTuNhanXungNgoiThuNhat.chungToi, "chung toi", "chúng tôi");
            this.daiTuNhanXungNgoiThuNhat.words.Add(myWord);

            myWord = new Word((int)DaiTuNhanXungNgoiThuNhat.chungTo, "chung to", "chúng tớ");
            this.daiTuNhanXungNgoiThuNhat.words.Add(myWord);

            myWord = new Word((int)DaiTuNhanXungNgoiThuNhat.minh, "minh", "mình");
            this.daiTuNhanXungNgoiThuNhat.words.Add(myWord);

            myWord = new Word((int)DaiTuNhanXungNgoiThuNhat.ta, "ta", "ta");
            this.daiTuNhanXungNgoiThuNhat.words.Add(myWord);

            myWord = new Word((int)DaiTuNhanXungNgoiThuNhat.tao, "tao", "tao");
            this.daiTuNhanXungNgoiThuNhat.words.Add(myWord);

            myWord = new Word((int)DaiTuNhanXungNgoiThuNhat.toi, "toi", "tôi");
            this.daiTuNhanXungNgoiThuNhat.words.Add(myWord);

            myWord = new Word((int)DaiTuNhanXungNgoiThuNhat.to, "to", "tớ");
            this.daiTuNhanXungNgoiThuNhat.words.Add(myWord);

            myWord = new Word((int)DaiTuNhanXungNgoiThuNhat.tuiToi, "tui toi", "tụi tôi");
            this.daiTuNhanXungNgoiThuNhat.words.Add(myWord);

            myWord = new Word((int)DaiTuNhanXungNgoiThuNhat.tuiTo, "tui to", "tụi tớ");
            this.daiTuNhanXungNgoiThuNhat.words.Add(myWord);

            myWord = new Word((int)DaiTuNhanXungNgoiThuNhat.tuiMinh, "tui minh", "tụi mình");
            this.daiTuNhanXungNgoiThuNhat.words.Add(myWord);

            #endregion

            #region Step 18. Initialize List daiTuNhanXungNgoiThuHai

            //Init list
            this.daiTuNhanXungNgoiThuHai = new WordsList();

            this.daiTuNhanXungNgoiThuHai.wordType = (int)TuLoai.daiTuNhanXungNgoiThuHai;

            myWord = new Word((int)DaiTuNhanXungNgoiThuHai.ban, "ban", "bạn");
            this.daiTuNhanXungNgoiThuHai.words.Add(myWord);

            myWord = new Word((int)DaiTuNhanXungNgoiThuHai.cacBan, "cac ban", "các bạn");
            this.daiTuNhanXungNgoiThuHai.words.Add(myWord);

            myWord = new Word((int)DaiTuNhanXungNgoiThuHai.cacCau, "cac cau", "các cậu");
            this.daiTuNhanXungNgoiThuHai.words.Add(myWord);

            myWord = new Word((int)DaiTuNhanXungNgoiThuHai.cau, "cau", "cậu");
            this.daiTuNhanXungNgoiThuHai.words.Add(myWord);

            myWord = new Word((int)DaiTuNhanXungNgoiThuHai.chungMay, "chung may", "chúng mày");
            this.daiTuNhanXungNgoiThuHai.words.Add(myWord);

            myWord = new Word((int)DaiTuNhanXungNgoiThuHai.may, "may", "mày");
            this.daiTuNhanXungNgoiThuHai.words.Add(myWord);

            #endregion

            #region Step 19. Initialize List trangTuChiMucDo
            //Init list
            this.trangTuChiMucDo = new WordsList();

            this.trangTuChiMucDo.wordType = (int)TuLoai.trangTuChiMucDo;

            myWord = new Word((int)TrangTuChiMucDo.cucKy, "cuc ky", "cực kỳ");
            this.trangTuChiMucDo.words.Add(myWord);

            myWord = new Word((int)TrangTuChiMucDo.cuc, "cuc", "cực");
            this.trangTuChiMucDo.words.Add(myWord);

            myWord = new Word((int)TrangTuChiMucDo.hoanToan, "hoan toan", "hoàn toàn");
            this.trangTuChiMucDo.words.Add(myWord);

            myWord = new Word((int)TrangTuChiMucDo.hoiHoi, "hoi hoi", "hơi hơi");
            this.trangTuChiMucDo.words.Add(myWord);

            myWord = new Word((int)TrangTuChiMucDo.hoi, "hoi", "hơi");
            this.trangTuChiMucDo.words.Add(myWord);

            myWord = new Word((int)TrangTuChiMucDo.khaKha, "kha kha", "kha khá");
            this.trangTuChiMucDo.words.Add(myWord);

            myWord = new Word((int)TrangTuChiMucDo.kha, "kha", "khá");
            this.trangTuChiMucDo.words.Add(myWord);

            myWord = new Word((int)TrangTuChiMucDo.ratRat, "rat rat", "rất rất");
            this.trangTuChiMucDo.words.Add(myWord);

            myWord = new Word((int)TrangTuChiMucDo.rat, "rat", "rat");
            this.trangTuChiMucDo.words.Add(myWord);

            myWord = new Word((int)TrangTuChiMucDo.thucSu, "thuc su", "thực sự");
            this.trangTuChiMucDo.words.Add(myWord);

            myWord = new Word((int)TrangTuChiMucDo.voCung, "vo cung", "vô cùng");
            this.trangTuChiMucDo.words.Add(myWord);

            #endregion

            #region Step 20. Initialize List trangTuChiTanSuatDiTruocDTNX
            //Init list
            this.trangTuChiTanSuatDiTruocDTNX = new WordsList();

            this.trangTuChiTanSuatDiTruocDTNX.wordType = (int)TuLoai.trangTuChiTanSuatDiTruocDTNX;

            myWord = new Word((int)TrangTuChiTanSuatDiTruocDTNX.doiKhi, "doi khi", "đôi khi");
            this.trangTuChiTanSuatDiTruocDTNX.words.Add(myWord);

            myWord = new Word((int)TrangTuChiTanSuatDiTruocDTNX.doiLuc, "doi luc", "đôi lúc");
            this.trangTuChiTanSuatDiTruocDTNX.words.Add(myWord);

            myWord = new Word((int)TrangTuChiTanSuatDiTruocDTNX.lamKhi, "lam khi", "lắm khi");
            this.trangTuChiTanSuatDiTruocDTNX.words.Add(myWord);

            myWord = new Word((int)TrangTuChiTanSuatDiTruocDTNX.nhieuKhi, "nhieu khi", "nhiều khi");
            this.trangTuChiTanSuatDiTruocDTNX.words.Add(myWord);

            myWord = new Word((int)TrangTuChiTanSuatDiTruocDTNX.nhieuLuc, "nhieu luc", "nhiều lúc");
            this.trangTuChiTanSuatDiTruocDTNX.words.Add(myWord);

            myWord = new Word((int)TrangTuChiTanSuatDiTruocDTNX.thinhThoang, "thinh thoang", "thinh thoang");
            this.trangTuChiTanSuatDiTruocDTNX.words.Add(myWord);

            #endregion

            #region Step 21. Initialize List trangTuChiTanSuatDiSauDTNX
            //Init list
            this.trangTuChiTanSuatDiSauDTNX = new WordsList();

            this.trangTuChiTanSuatDiSauDTNX.wordType = (int)TuLoai.trangTuChiTanSuatDiSauDTNX;

            myWord = new Word((int)TrangTuChiTanSuatDiSauDTNX.doiKhi, "doi khi", "đôi khi");
            this.trangTuChiTanSuatDiSauDTNX.words.Add(myWord);

            myWord = new Word((int)TrangTuChiTanSuatDiSauDTNX.hay, "hay", "hay");
            this.trangTuChiTanSuatDiSauDTNX.words.Add(myWord);

            myWord = new Word((int)TrangTuChiTanSuatDiSauDTNX.lamKhi, "lam khi", "lắm khi");
            this.trangTuChiTanSuatDiSauDTNX.words.Add(myWord);

            myWord = new Word((int)TrangTuChiTanSuatDiSauDTNX.luonLuon, "luon luon", "luôn luôn");
            this.trangTuChiTanSuatDiSauDTNX.words.Add(myWord);

            myWord = new Word((int)TrangTuChiTanSuatDiSauDTNX.nhieuKhi, "nhieu khi", "nhiều khi");
            this.trangTuChiTanSuatDiSauDTNX.words.Add(myWord);

            myWord = new Word((int)TrangTuChiTanSuatDiSauDTNX.nhieuLuc, "nhieu luc", "nhiều lúc");
            this.trangTuChiTanSuatDiSauDTNX.words.Add(myWord);

            myWord = new Word((int)TrangTuChiTanSuatDiSauDTNX.ratHay, "rat hay", "rất hay");
            this.trangTuChiTanSuatDiSauDTNX.words.Add(myWord);

            #endregion
        }

        public Dictionary(string botName, string userName)
            : this()
        {
            Word myWord;
            myWord = new Word((int)DaiTuNhanXungNgoiThuNhat.user, userName, userName);
            this.daiTuNhanXungNgoiThuNhat.words.Add(myWord);

            myWord = new Word((int)DaiTuNhanXungNgoiThuHai.bot, botName, botName);
            this.daiTuNhanXungNgoiThuHai.words.Add(myWord);
        }

    }
}