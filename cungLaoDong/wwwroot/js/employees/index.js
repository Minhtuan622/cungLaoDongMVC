const laborDemo = [
    {
        id: 1,
        ho_ten: "Nguyễn Văn An",
        ngay_sinh: "15/03/1990",
        gioi_tinh: "Nam",
        cccd: "123456789012",
        thuong_tru: "123 Đường Láng, Đống Đa, Hà Nội",
        tam_tru: "",
        doi_tuong_uu_tien: "",
        trinh_do_pho_thong: "Tốt nghiệp THPT",
        trinh_do_chuyen_mon: "Đại học",
        chuyen_nganh_dao_tao: "Công nghệ thông tin",
        tinh_trang_hoat_dong: "Có việc làm",
        vi_the_viec_lam: "Làm công ăn lương",
        cong_viec: "Lập trình viên",
        noi_lam_viec: "Công ty FPT, Cầu Giấy, Hà Nội",
        thoi_gian_that_nghiep: "",
        nhu_cau_viec_lam: "",
        trinh_do_dao_tao_hien_tai: "",
        chuyen_nganh_hien_tai: "",
        thoi_gian_tot_nghiep: ""
    },
    {
        id: 2,
        ho_ten: "Trần Thị Bình",
        ngay_sinh: "22/07/1995",
        gioi_tinh: "Nữ",
        cccd: "987654321098",
        thuong_tru: "45 Nguyễn Huệ, Quận 1, TP.HCM",
        tam_tru: "",
        doi_tuong_uu_tien: "Hộ nghèo",
        trinh_do_pho_thong: "Tốt nghiệp THCS",
        trinh_do_chuyen_mon: "Trung cấp",
        chuyen_nganh_dao_tao: "Kế toán",
        tinh_trang_hoat_dong: "Thất nghiệp",
        vi_the_viec_lam: "",
        cong_viec: "",
        noi_lam_viec: "",
        thoi_gian_that_nghiep: "Từ 3 tháng đến 1 năm",
        nhu_cau_viec_lam: "Kế toán viên",
        trinh_do_dao_tao_hien_tai: "",
        chuyen_nganh_hien_tai: "",
        thoi_gian_tot_nghiep: ""
    },
    {
        id: 3,
        ho_ten: "Lê Văn Cường",
        ngay_sinh: "10/11/2000",
        gioi_tinh: "Nam",
        cccd: "456789123456",
        thuong_tru: "Thôn 3, Long Thành, Đồng Nai",
        tam_tru: "123 Lê Lợi, Biên Hòa, Đồng Nai",
        doi_tuong_uu_tien: "Dân tộc thiểu số",
        trinh_do_pho_thong: "Chưa học xong Tiểu học",
        trinh_do_chuyen_mon: "Chưa qua đào tạo",
        chuyen_nganh_dao_tao: "",
        tinh_trang_hoat_dong: "Không tham gia",
        vi_the_viec_lam: "",
        cong_viec: "",
        noi_lam_viec: "",
        thoi_gian_that_nghiep: "",
        nhu_cau_viec_lam: "",
        trinh_do_dao_tao_hien_tai: "Sơ cấp",
        chuyen_nganh_hien_tai: "Cơ khí",
        thoi_gian_tot_nghiep: "12/2025"
    },
    {
        id: 4,
        ho_ten: "Phạm Thị Dung",
        ngay_sinh: "05/02/1985",
        gioi_tinh: "Nữ",
        cccd: "789123456789",
        thuong_tru: "12 Lê Nin, Hạ Long, Quảng Ninh",
        tam_tru: "",
        doi_tuong_uu_tien: "",
        trinh_do_pho_thong: "Tốt nghiệp THPT",
        trinh_do_chuyen_mon: "Cao đẳng",
        chuyen_nganh_dao_tao: "Du lịch",
        tinh_trang_hoat_dong: "Có việc làm",
        vi_the_viec_lam: "Tự làm",
        cong_viec: "Hướng dẫn viên du lịch",
        noi_lam_viec: "Hạ Long, Quảng Ninh",
        thoi_gian_that_nghiep: "",
        nhu_cau_viec_lam: "",
        trinh_do_dao_tao_hien_tai: "",
        chuyen_nganh_hien_tai: "",
        thoi_gian_tot_nghiep: ""
    },
    {
        id: 5,
        ho_ten: "Hoàng Văn Em",
        ngay_sinh: "30/12/1992",
        gioi_tinh: "Nam",
        cccd: "321654987123",
        thuong_tru: "Thôn 5, Nghi Lộc, Thanh Hóa",
        tam_tru: "",
        doi_tuong_uu_tien: "Khuyết tật",
        trinh_do_pho_thong: "Tốt nghiệp THCS",
        trinh_do_chuyen_mon: "Sơ cấp",
        chuyen_nganh_dao_tao: "Xây dựng",
        tinh_trang_hoat_dong: "Thất nghiệp",
        vi_the_viec_lam: "",
        cong_viec: "",
        noi_lam_viec: "",
        thoi_gian_that_nghiep: "Dưới 3 tháng",
        nhu_cau_viec_lam: "Công nhân xây dựng",
        trinh_do_dao_tao_hien_tai: "",
        chuyen_nganh_hien_tai: "",
        thoi_gian_tot_nghiep: ""
    },
    {
        id: 6,
        ho_ten: "Đặng Thị Phượng",
        ngay_sinh: "12/08/1998",
        gioi_tinh: "Nữ",
        cccd: "654321987654",
        thuong_tru: "45 Trần Phú, Hải Phòng",
        tam_tru: "",
        doi_tuong_uu_tien: "",
        trinh_do_pho_thong: "Tốt nghiệp Tiểu học",
        trinh_do_chuyen_mon: "Chưa qua đào tạo",
        chuyen_nganh_dao_tao: "",
        tinh_trang_hoat_dong: "Không tham gia",
        vi_the_viec_lam: "",
        cong_viec: "",
        noi_lam_viec: "",
        thoi_gian_that_nghiep: "",
        nhu_cau_viec_lam: "",
        trinh_do_dao_tao_hien_tai: "Đại học",
        chuyen_nganh_hien_tai: "Sư phạm",
        thoi_gian_tot_nghiep: "06/2026"
    },
    {
        id: 7,
        ho_ten: "Nguyễn Thị Lan",
        ngay_sinh: "03/04/1988",
        gioi_tinh: "Nữ",
        cccd: "123987456321",
        thuong_tru: "67 Kim Mã, Ba Đình, Hà Nội",
        tam_tru: "",
        doi_tuong_uu_tien: "Hộ nghèo",
        trinh_do_pho_thong: "Tốt nghiệp THPT",
        trinh_do_chuyen_mon: "Đại học",
        chuyen_nganh_dao_tao: "Kinh tế",
        tinh_trang_hoat_dong: "Có việc làm",
        vi_the_viec_lam: "Làm công ăn lương",
        cong_viec: "Nhân viên ngân hàng",
        noi_lam_viec: "Ngân hàng Vietcombank, Hà Nội",
        thoi_gian_that_nghiep: "",
        nhu_cau_viec_lam: "",
        trinh_do_dao_tao_hien_tai: "",
        chuyen_nganh_hien_tai: "",
        thoi_gian_tot_nghiep: ""
    },
    {
        id: 8,
        ho_ten: "Trần Văn Hùng",
        ngay_sinh: "25/06/1993",
        gioi_tinh: "Nam",
        cccd: "456123789654",
        thuong_tru: "89 Lê Lợi, Quận 3, TP.HCM",
        tam_tru: "",
        doi_tuong_uu_tien: "",
        trinh_do_pho_thong: "Tốt nghiệp THCS",
        trinh_do_chuyen_mon: "Trung cấp",
        chuyen_nganh_dao_tao: "Cơ khí",
        tinh_trang_hoat_dong: "Thất nghiệp",
        vi_the_viec_lam: "",
        cong_viec: "",
        noi_lam_viec: "",
        thoi_gian_that_nghiep: "Trên 1 năm",
        nhu_cau_viec_lam: "Kỹ thuật viên cơ khí",
        trinh_do_dao_tao_hien_tai: "",
        chuyen_nganh_hien_tai: "",
        thoi_gian_tot_nghiep: ""
    },
    {
        id: 9,
        ho_ten: "Lê Thị Mai",
        ngay_sinh: "14/09/1997",
        gioi_tinh: "Nữ",
        cccd: "789456123987",
        thuong_tru: "Thôn 7, Trảng Bom, Đồng Nai",
        tam_tru: "",
        doi_tuong_uu_tien: "Dân tộc thiểu số",
        trinh_do_pho_thong: "Tốt nghiệp THPT",
        trinh_do_chuyen_mon: "Cao đẳng",
        chuyen_nganh_dao_tao: "Điều dưỡng",
        tinh_trang_hoat_dong: "Có việc làm",
        vi_the_viec_lam: "Làm công ăn lương",
        cong_viec: "Y tá",
        noi_lam_viec: "Bệnh viện Đồng Nai, Đồng Nai",
        thoi_gian_that_nghiep: "",
        nhu_cau_viec_lam: "",
        trinh_do_dao_tao_hien_tai: "",
        chuyen_nganh_hien_tai: "",
        thoi_gian_tot_nghiep: ""
    },
    {
        id: 10,
        ho_ten: "Phạm Văn Khang",
        ngay_sinh: "08/01/1987",
        gioi_tinh: "Nam",
        cccd: "321789654123",
        thuong_tru: "123 Hùng Vương, Uông Bí, Quảng Ninh",
        tam_tru: "",
        doi_tuong_uu_tien: "",
        trinh_do_pho_thong: "Tốt nghiệp THCS",
        trinh_do_chuyen_mon: "Sơ cấp",
        chuyen_nganh_dao_tao: "Hàn",
        tinh_trang_hoat_dong: "Không tham gia",
        vi_the_viec_lam: "",
        cong_viec: "",
        noi_lam_viec: "",
        thoi_gian_that_nghiep: "",
        nhu_cau_viec_lam: "",
        trinh_do_dao_tao_hien_tai: "",
        chuyen_nganh_hien_tai: "",
        thoi_gian_tot_nghiep: ""
    },
    {
        id: 11,
        ho_ten: "Hoàng Thị Ngọc",
        ngay_sinh: "19/05/1994",
        gioi_tinh: "Nữ",
        cccd: "654987321456",
        thuong_tru: "Thôn 2, Hàm Thuận, Thanh Hóa",
        tam_tru: "",
        doi_tuong_uu_tien: "Khuyết tật",
        trinh_do_pho_thong: "Tốt nghiệp THPT",
        trinh_do_chuyen_mon: "Đại học",
        chuyen_nganh_dao_tao: "Luật",
        tinh_trang_hoat_dong: "Có việc làm",
        vi_the_viec_lam: "Làm công ăn lương",
        cong_viec: "Luật sư",
        noi_lam_viec: "Văn phòng luật Thanh Hóa, Thanh Hóa",
        thoi_gian_that_nghiep: "",
        nhu_cau_viec_lam: "",
        trinh_do_dao_tao_hien_tai: "",
        chuyen_nganh_hien_tai: "",
        thoi_gian_tot_nghiep: ""
    },
    {
        id: 12,
        ho_ten: "Đặng Văn Long",
        ngay_sinh: "27/10/1991",
        gioi_tinh: "Nam",
        cccd: "987123456789",
        thuong_tru: "56 Nguyễn Trãi, Hải Phòng",
        tam_tru: "",
        doi_tuong_uu_tien: "",
        trinh_do_pho_thong: "Tốt nghiệp THCS",
        trinh_do_chuyen_mon: "Trung cấp",
        chuyen_nganh_dao_tao: "Điện tử",
        tinh_trang_hoat_dong: "Thất nghiệp",
        vi_the_viec_lam: "",
        cong_viec: "",
        noi_lam_viec: "",
        thoi_gian_that_nghiep: "Dưới 3 tháng",
        nhu_cau_viec_lam: "Kỹ thuật viên điện tử",
        trinh_do_dao_tao_hien_tai: "",
        chuyen_nganh_hien_tai: "",
        thoi_gian_tot_nghiep: ""
    },
    {
        id: 13,
        ho_ten: "Nguyễn Văn Minh",
        ngay_sinh: "04/02/2001",
        gioi_tinh: "Nam",
        cccd: "123654789321",
        thuong_tru: "78 Hoàn Kiếm, Hà Nội",
        tam_tru: "",
        doi_tuong_uu_tien: "Hộ nghèo",
        trinh_do_pho_thong: "Chưa học xong Tiểu học",
        trinh_do_chuyen_mon: "Chưa qua đào tạo",
        chuyen_nganh_dao_tao: "",
        tinh_trang_hoat_dong: "Không tham gia",
        vi_the_viec_lam: "",
        cong_viec: "",
        noi_lam_viec: "",
        thoi_gian_that_nghiep: "",
        nhu_cau_viec_lam: "",
        trinh_do_dao_tao_hien_tai: "Cao đẳng",
        chuyen_nganh_hien_tai: "Xây dựng",
        thoi_gian_tot_nghiep: "07/2024"
    },
    {
        id: 14,
        ho_ten: "Trần Thị Hồng",
        ngay_sinh: "16/07/1989",
        gioi_tinh: "Nữ",
        cccd: "456987123654",
        thuong_tru: "34 Pasteur, Quận 1, TP.HCM",
        tam_tru: "",
        doi_tuong_uu_tien: "",
        trinh_do_pho_thong: "Tốt nghiệp THPT",
        trinh_do_chuyen_mon: "Cao đẳng",
        chuyen_nganh_dao_tao: "Marketing",
        tinh_trang_hoat_dong: "Có việc làm",
        vi_the_viec_lam: "Làm công ăn lương",
        cong_viec: "Nhân viên marketing",
        noi_lam_viec: "Công ty Unilever, TP.HCM",
        thoi_gian_that_nghiep: "",
        nhu_cau_viec_lam: "",
        trinh_do_dao_tao_hien_tai: "",
        chuyen_nganh_hien_tai: "",
        thoi_gian_tot_nghiep: ""
    },
    {
        id: 15,
        ho_ten: "Lê Văn Nam",
        ngay_sinh: "23/03/1996",
        gioi_tinh: "Nam",
        cccd: "789321456987",
        thuong_tru: "Thôn 4, Long Thành, Đồng Nai",
        tam_tru: "",
        doi_tuong_uu_tien: "Dân tộc thiểu số",
        trinh_do_pho_thong: "Tốt nghiệp THCS",
        trinh_do_chuyen_mon: "Sơ cấp",
        chuyen_nganh_dao_tao: "Nông nghiệp",
        tinh_trang_hoat_dong: "Thất nghiệp",
        vi_the_viec_lam: "",
        cong_viec: "",
        noi_lam_viec: "",
        thoi_gian_that_nghiep: "Từ 3 tháng đến 1 năm",
        nhu_cau_viec_lam: "Công nhân nông nghiệp",
        trinh_do_dao_tao_hien_tai: "",
        chuyen_nganh_hien_tai: "",
        thoi_gian_tot_nghiep: ""
    },
    {
        id: 16,
        ho_ten: "Phạm Thị Oanh",
        ngay_sinh: "11/11/1999",
        gioi_tinh: "Nữ",
        cccd: "321456789123",
        thuong_tru: "23 Bãi Cháy, Quảng Ninh",
        tam_tru: "",
        doi_tuong_uu_tien: "",
        trinh_do_pho_thong: "Tốt nghiệp THPT",
        trinh_do_chuyen_mon: "Đại học",
        chuyen_nganh_dao_tao: "Quản trị kinh doanh",
        tinh_trang_hoat_dong: "Có việc làm",
        vi_the_viec_lam: "Chủ cơ sở SXKD",
        cong_viec: "Chủ cửa hàng",
        noi_lam_viec: "Cửa hàng Oanh, Quảng Ninh",
        thoi_gian_that_nghiep: "",
        nhu_cau_viec_lam: "",
        trinh_do_dao_tao_hien_tai: "",
        chuyen_nganh_hien_tai: "",
        thoi_gian_tot_nghiep: ""
    },
    {
        id: 17,
        ho_ten: "Hoàng Văn Phong",
        ngay_sinh: "29/04/1986",
        gioi_tinh: "Nam",
        cccd: "654789123456",
        thuong_tru: "Thôn 6, Đông Hưng, Thanh Hóa",
        tam_tru: "",
        doi_tuong_uu_tien: "Khuyết tật",
        trinh_do_pho_thong: "Tốt nghiệp Tiểu học",
        trinh_do_chuyen_mon: "Trung cấp",
        chuyen_nganh_dao_tao: "Điện",
        tinh_trang_hoat_dong: "Không tham gia",
        vi_the_viec_lam: "",
        cong_viec: "",
        noi_lam_viec: "",
        thoi_gian_that_nghiep: "",
        nhu_cau_viec_lam: "",
        trinh_do_dao_tao_hien_tai: "",
        chuyen_nganh_hien_tai: "",
        thoi_gian_tot_nghiep: ""
    },
    {
        id: 18,
        ho_ten: "Đặng Thị Quyên",
        ngay_sinh: "07/08/1992",
        gioi_tinh: "Nữ",
        cccd: "987456321789",
        thuong_tru: "78 Cát Bi, Hải Phòng",
        tam_tru: "",
        doi_tuong_uu_tien: "",
        trinh_do_pho_thong: "Tốt nghiệp THCS",
        trinh_do_chuyen_mon: "Chưa qua đào tạo",
        chuyen_nganh_dao_tao: "",
        tinh_trang_hoat_dong: "Thất nghiệp",
        vi_the_viec_lam: "",
        cong_viec: "",
        noi_lam_viec: "",
        thoi_gian_that_nghiep: "Trên 1 năm",
        nhu_cau_viec_lam: "Nhân viên bán hàng",
        trinh_do_dao_tao_hien_tai: "",
        chuyen_nganh_hien_tai: "",
        thoi_gian_tot_nghiep: ""
    },
    {
        id: 19,
        ho_ten: "Nguyễn Văn Sơn",
        ngay_sinh: "18/06/1990",
        gioi_tinh: "Nam",
        cccd: "123789456321",
        thuong_tru: "45 Giảng Võ, Đống Đa, Hà Nội",
        tam_tru: "",
        doi_tuong_uu_tien: "Hộ nghèo",
        trinh_do_pho_thong: "Tốt nghiệp THPT",
        trinh_do_chuyen_mon: "Cao đẳng",
        chuyen_nganh_dao_tao: "Xây dựng",
        tinh_trang_hoat_dong: "Có việc làm",
        vi_the_viec_lam: "Lao động gia đình",
        cong_viec: "Công nhân xây dựng",
        noi_lam_viec: "Công ty xây dựng Hòa Bình, Hà Nội",
        thoi_gian_that_nghiep: "",
        nhu_cau_viec_lam: "",
        trinh_do_dao_tao_hien_tai: "",
        chuyen_nganh_hien_tai: "",
        thoi_gian_tot_nghiep: ""
    },
    {
        id: 20,
        ho_ten: "Trần Thị Thảo",
        ngay_sinh: "26/12/1995",
        gioi_tinh: "Nữ",
        cccd: "456123987654",
        thuong_tru: "56 Võ Thị Sáu, Quận 3, TP.HCM",
        tam_tru: "",
        doi_tuong_uu_tien: "",
        trinh_do_pho_thong: "Tốt nghiệp THCS",
        trinh_do_chuyen_mon: "Sơ cấp",
        chuyen_nganh_dao_tao: "May công nghiệp",
        tinh_trang_hoat_dong: "Không tham gia",
        vi_the_viec_lam: "",
        cong_viec: "",
        noi_lam_viec: "",
        thoi_gian_that_nghiep: "",
        nhu_cau_viec_lam: "",
        trinh_do_dao_tao_hien_tai: "",
        chuyen_nganh_hien_tai: "",
        thoi_gian_tot_nghiep: ""
    }
];

function calculateAge(ngay_sinh) {
    const birthDate = new Date(ngay_sinh.split('/').reverse().join('-'));
    const today = new Date();
    let age = today.getFullYear() - birthDate.getFullYear();
    const monthDiff = today.getMonth() - birthDate.getMonth();
    if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < birthDate.getDate())) age--;
    return age;
}

function displayLaborList(data) {
    const laborTable = $('#laborTable');
    laborTable.html('');
    data.forEach((labor) => {
        laborTable.append(`
            <tr>
                <td>${labor.ho_ten}</td>
                <td>${labor.cccd}</td>
                <td>${labor.ngay_sinh}</td>
                <td>${labor.gioi_tinh}</td>
                <td>${labor.thuong_tru}</td>
                <td>${labor.tam_tru || 'Không'}</td>
                <td>${labor.doi_tuong_uu_tien || 'Không'}</td>
                <td>${labor.trinh_do_pho_thong}</td>
                <td>${labor.trinh_do_chuyen_mon}</td>
                <td>${labor.chuyen_nganh_dao_tao || 'Không'}</td>
                <td>${labor.tinh_trang_hoat_dong}</td>
                <td>${labor.vi_the_viec_lam || 'Không'}</td>
                <td>${labor.cong_viec || 'Không'}</td>
                <td>${labor.noi_lam_viec || 'Không'}</td>
                <td>${labor.thoi_gian_that_nghiep || 'Không'}</td>
                <td>${labor.nhu_cau_viec_lam || 'Không'}</td>
                <td>${labor.trinh_do_dao_tao_hien_tai || 'Không'}</td>
                <td>${labor.chuyen_nganh_hien_tai || 'Không'}</td>
                <td>${labor.thoi_gian_tot_nghiep || 'Không'}</td>
                <td>
                    <div class="dropdown">
                        <button class="btn btn-primary dropdown-toggle" type="button"
                            id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false">
                            <i class="fas fa-bars"></i>
                        </button>
                        <ul class="dropdown-menu animated--fade-in" aria-labelledby="dropdownMenuButton">
                            <li><a class="dropdown-item" asp-controller="Employees" asp-action="Show">Xem</a></li>
                            <li><a class="dropdown-item" asp-controller="Employees" asp-action="Update">Sửa</a></li>
                            <li><a class="dropdown-item text-danger" href="#">Xóa</a></li>
                        </ul>
                    </div>
                </td>
            </tr>
        `);
    });
}

function applyCustomFilter() {
    const tinh_trang = $('#tinh_trang_hoat_dong').val();
    const trinh_do_chuyen_mon = $('#trinh_do_chuyen_mon').val();
    const gioi_tinh = $('#gioi_tinh').val();
    const do_tuoi = $('#do_tuoi').val();
    const tinh_tp = $('#tinh_tp').val();
    const doi_tuong = $('#doi_tuong_uu_tien').val();
    const tam_tru = $('#tam_tru').val();
    const trinh_do_pho_thong = $('#trinh_do_pho_thong').val();
    const chuyen_nganh_dao_tao = $('#chuyen_nganh_dao_tao').val();
    const vi_the_viec_lam = $('#vi_the_viec_lam').val();
    const cong_viec = $('#cong_viec').val();
    const noi_lam_viec = $('#noi_lam_viec').val();
    const thoi_gian_that_nghiep = $('#thoi_gian_that_nghiep').val();
    const nhu_cau_viec_lam = $('#nhu_cau_viec_lam').val();
    const trinh_do_dao_tao_hien_tai = $('#trinh_do_dao_tao_hien_tai').val();
    const chuyen_nganh_hien_tai = $('#chuyen_nganh_hien_tai').val();
    const thoi_gian_tot_nghiep = $('#thoi_gian_tot_nghiep').val();

    $.fn.dataTable.ext.search = [];

    $.fn.dataTable.ext.search.push(function (settings, data) {
        const ngaySinh = data[2];
        const gioiTinh = data[3];
        const thuongTru = data[4];
        const tamTru = data[5] || '';
        const doiTuongUuTien = data[6] || '';
        const trinhDoPhoThong = data[7];
        const trinhDoChuyenMon = data[8];
        const chuyenNganhDaoTao = data[9] || '';
        const tinhTrang = data[10];
        const viTheViecLam = data[11] || '';
        const congViec = data[12] || '';
        const noiLamViec = data[13] || '';
        const thoiGianThatNghiep = data[14] || '';
        const nhuCauViecLam = data[15] || '';
        const trinhDoDaoTaoHienTai = data[16] || '';
        const chuyenNganhHienTai = data[17] || '';
        const thoiGianTotNghiep = data[18] || '';

        const age = calculateAge(ngaySinh);

        if (gioi_tinh && gioiTinh !== gioi_tinh) return false;
        if (tinh_tp && !thuongTru.includes(tinh_tp)) return false;
        if (tam_tru && !tamTru.includes(tam_tru)) return false;
        if (doi_tuong && doiTuongUuTien !== doi_tuong) return false;
        if (trinh_do_pho_thong && trinhDoPhoThong !== trinh_do_pho_thong) return false;
        if (trinh_do_chuyen_mon && trinhDoChuyenMon !== trinh_do_chuyen_mon) return false;
        if (chuyen_nganh_dao_tao && chuyenNganhDaoTao !== chuyen_nganh_dao_tao) return false;
        if (tinh_trang && tinhTrang !== tinh_trang) return false;
        if (vi_the_viec_lam && viTheViecLam !== vi_the_viec_lam) return false;
        if (cong_viec && congViec !== cong_viec) return false;
        if (noi_lam_viec && !noiLamViec.includes(noi_lam_viec)) return false;
        if (thoi_gian_that_nghiep && thoiGianThatNghiep !== thoi_gian_that_nghiep) return false;
        if (nhu_cau_viec_lam && nhuCauViecLam !== nhu_cau_viec_lam) return false;
        if (trinh_do_dao_tao_hien_tai && trinhDoDaoTaoHienTai !== trinh_do_dao_tao_hien_tai) return false;
        if (chuyen_nganh_hien_tai && chuyenNganhHienTai !== chuyen_nganh_hien_tai) return false;
        if (thoi_gian_tot_nghiep && thoiGianTotNghiep !== thoi_gian_tot_nghiep) return false;

        if (do_tuoi) {
            if (do_tuoi === '15-24' && (age < 15 || age > 24)) return false;
            if (do_tuoi === '25-34' && (age < 25 || age > 34)) return false;
            if (do_tuoi === '35-44' && (age < 35 || age > 44)) return false;
            if (do_tuoi === '45+' && age < 45) return false;
        }

        return true;
    });

    $('#dataTable').DataTable().draw();
    $('#filterModal').hide();
}

$(document).ready(function () {
    displayLaborList(laborDemo);

    $('#resetFilter').click(function () {
        $('#filterForm')[0].reset();
        $('#dataTable').DataTable().draw();
    })

    $('#applyFilter').click(function () {
        applyCustomFilter();
        $('#filterModal').hide();
    })
})
