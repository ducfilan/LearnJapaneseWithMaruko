namespace Hoc_tieng_Nhat_cung_Maruko.Controller.Bot
{
    public enum DanhTuChiDonVi
    {
        cai = 1,
        chiec = 2,
        can = 3,
        doan = 4,
        dan = 5,
        nhom = 6,
        cum = 7
    }

    public enum DanhTuChiSuVat
    {
        tu = 1,
        bai = 2,
        chuCai = 3,
        tieng = 4,
        baiHat = 5,
        chucNang = 6,
        cumTu = 7,
        tinhYeu = 8
        
    }

    public enum DongTuChiTinhThai
    {
        nen = 1,
        can = 2,
        coThe = 3,
        khongThe = 4,
        canPhai = 5,
        khongNen = 6
    }
    public enum DongTuChiHanhDong
    {
        biet = 1,
        dich = 2,
        hat = 3,
        doc = 4,
        noi = 5,
        tra = 6,
        mo = 7,
        giup = 8,
        nghi = 9,
        di = 10,
        dung = 11,
        ngoi = 12,
        noiChuyen = 13,
        giaiNghia = 14,
        phatAm = 15,
        giaiThich = 16,
        giupDo = 17,
        camOn = 18,
        cho = 19,
        choBiet = 20
    }

    public enum TinhTuChiDacDiemTuongDoi
    {
        xinh = 1,
        dep = 2,
        khoe = 3,
        gay = 4,
        beo = 5,
        xau = 6,
        tot = 7,
        tre = 8,
        gia = 9,
        xinhDep = 10,
        xauXi = 11,
        taiGioi = 12,
        thongMinh = 13,
        ngocNghech = 14,
        taiCan = 15,
        nguNgoc = 16,
        thanKinh = 17,
        buon = 18,
        vui = 19,
        chan = 20
    }

    public enum TinhTuChiDacDiemTuyetDoi
    {
        thomPhuc = 1,
        doLom = 2,
        trangToat = 3,
        xanhLe = 4
    }

    public enum SoTu 
    {
        mot = 1,
        hai = 2,
        ba = 3,
        bon = 4,
        nam = 5
    }

    public enum DaiTuChiNguoi
    {
        minh = 1,
        tao = 2,
        toi = 3,
        to = 4,
        chungMinh = 5,
        bonTao = 6,
        chungToi = 7,
        ta = 8,
        bonNo = 9,
        chungNo = 10,
        tuiNo = 11,
        bonTo = 12,
        chungTo = 13,
        tuiTo = 14,
        cacCau = 15,
        cacBan = 16,
        han = 17,
        ho = 18
    }

    public enum DaiTuChiSuVat
    {
        chung = 1
    }

    public enum DaiTuDeHoi 
    {
        the = 1,
        ai = 2,
        gi = 3,
        baoNhieu = 4,
        may = 5
    }

    public enum LuongTu
    {
        nhung = 1,
        cac = 2,
        ca = 3,
        tung = 4,
        moi = 5
    }

    public enum ChiTu 
    {
        ay = 1,
        _do = 2,
        no = 3,
        kia = 4
    }

    public enum QuanHeTu 
    {
        cua = 1,
        vi = 2,
        nen = 3,
        ve = 4,
        bang = 5,
        o = 6,
        tuy = 7,
        nhung = 8,
        tuyNhien = 9,
        viThe = 10,
        doDo = 11,
        boiVay = 12
    }
   

    public enum PhoTu
    {
        da = 1,
        cung = 2,
        van = 3,
        rat = 4,
        vanChua = 5,
        that = 6
    }

    //Bieu thi thai do danh gia su vat, su viec
    public enum TroTu
    {
        thi = 1,
        ha = 2,
        ho = 4
    }

    public enum ThanTu
    {
        thanOi = 1,
        hoiOi = 2,
        troiOi = 3,
        hoi = 4,
        oi = 5 //ối
    }

    public enum TinhThaiTu
    {
        a = 1,
        oi = 2, // ôi
        nhe = 3,
        day = 4, //đấy
        thay = 5,
        aj = 6, //ạ
        nho = 7, //nhở
        nhi = 8, //nhỉ
        co = 9, //cơ
        ma = 10, //mà
        thi = 11, //thì
        nao = 12 //nào
    }

    public enum DaiTuNhanXungNgoiThuNhat
    {
        toi = 1,
        tao = 2,
        to = 3,
        minh = 4,
        user = 5,
        chungMinh = 6,
        bonTao = 7,
        chungToi = 8,
        ta = 9,
        tuiTo = 10,
        chungTo = 11,
        tuiToi = 12,
        tuiMinh = 13
    }

    public enum DaiTuNhanXungNgoiThuHai
    {
        cau = 1,
        may = 2,
        ban = 3,
        bot = 4,
        cacCau = 5,
        cacBan = 6,
        chungMay = 7,
    }

    public enum LoiNhanCuoiCau
    {
        nhe = 1,
        nha = 2,
        duocKhong = 3,
        duocHem = 4,
        khong = 5,
        voi = 6,
        voiNha = 7
    }

    public enum DongTuDiKemCamXuc
    {
        dang = 1,
        camThay = 2,
        dangCamThay = 3,
        thay = 4,
        chotThay = 5
    }

    public enum TrangTuChiMucDo
    {
        hoi = 1,
        rat = 2,
        ratRat = 3,
        kha = 4,
        voCung = 5,
        cucKy = 6,
        cuc = 7,
        hoiHoi = 8,
        hoanToan = 9,
        thucSu = 10,
        khaKha = 11
    }

    //Trang tu chi tan suat di sau dai tu nhan xung: (toi) hay, (toi) luon luon
    public enum TrangTuChiTanSuatDiSauDTNX
    {
        luon = 1,
        luonLuon = 2,
        hay = 3,
        ratHay = 4,
        doiKhi = 5,
        lamKhi = 6,
        nhieuKhi = 7,
        nhieuLuc = 8
    }

    //Trang tu chi tan suat di sau dai tu nhan xung: thinh thoang (toi)
    public enum TrangTuChiTanSuatDiTruocDTNX
    {
        thinhThoang = 1,
        doiKhi = 2,
        nhieuKhi = 3,
        lamKhi = 4,
        doiLuc = 5,
        nhieuLuc = 6
    }

    public enum TuLoai
    {
        danhTuChiDonVi = 1,
        danhTuChiSuVat = 2,
        dongTuChiTinhThai = 3,
        dongTuChiHanhDong = 4,
        tinhTuChiDacDiemTuongDoi = 5,
        tinhTuChiDacDiemTuyetDoi = 6,
        soTu = 7,
        daiTuChiNguoi = 8,
        daiTuChiSuVat = 9,
        daiTuDeHoi = 10,
        luongTu = 11,
        chiTu = 12,
        quanHeTu = 13,
        phoTu = 14,
        troTu = 15,
        thanTu = 16,
        tinhThaiTu = 17,
        loiNhoVaDauCau = 18,
        loiNhanCuoiCau = 19,
        daiTuNhanXungNgoiThuNhat = 20,
        daiTuNhanXungNgoiThuHai = 21,
        dongTuDiKemCamXuc = 22,
        trangTuChiMucDo = 23,
        trangTuChiTanSuatDiTruocDTNX = 24,
        trangTuChiTanSuatDiSauDTNX = 25
    }

    public class Word
    {
        public int id { get; set; }
        public string labelNoMark { get; set; }
        public string labelHasMark{ get; set; }

        public Word(int id, string labelNoMark, string labelHasMark)
        {
            this.id = id;
            this.labelNoMark = labelNoMark;
            this.labelHasMark = labelHasMark;
        }

    }
}