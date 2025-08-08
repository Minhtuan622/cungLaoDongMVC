// Load dữ liệu từ API
function loadEmployees() {
    $.ajax({
        url: '/Employees/GetEmployees',
        type: 'GET',
        dataType: 'json',
        success: function(response) {
            if (response.data) {
                displayLaborList(response.data);
            } else {
                console.error('Không có dữ liệu');
                $('#laborTable').html('<tr><td colspan="20" class="text-center">Không có dữ liệu</td></tr>');
            }
        },
        error: function(xhr, status, error) {
            console.error('Lỗi khi load dữ liệu:', error);
            $('#laborTable').html('<tr><td colspan="20" class="text-center text-danger">Lỗi khi tải dữ liệu</td></tr>');
        }
    });
}

// Load dữ liệu với filter từ server
function loadEmployeesWithFilter(filterData) {
    $.ajax({
        url: '/Employees/FilterEmployees',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(filterData),
        dataType: 'json',
        success: function(response) {
            if (response.data) {
                displayLaborList(response.data);
            } else {
                console.error('Không có dữ liệu');
                $('#laborTable').html('<tr><td colspan="20" class="text-center">Không có dữ liệu</td></tr>');
            }
        },
        error: function(xhr, status, error) {
            console.error('Lỗi khi filter dữ liệu:', error);
            $('#laborTable').html('<tr><td colspan="20" class="text-center text-danger">Lỗi khi filter dữ liệu</td></tr>');
        }
    });
}

function calculateAge(ngay_sinh) {
    if (!ngay_sinh) return 0;
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
    
    if (!data || data.length === 0) {
        laborTable.html('<tr><td colspan="20" class="text-center">Không có dữ liệu</td></tr>');
        return;
    }
    
    data.forEach((labor) => {
        laborTable.append(`
            <tr>
                <td>${labor.ho_ten || 'N/A'}</td>
                <td>${labor.cccd || 'N/A'}</td>
                <td>${labor.ngay_sinh || 'N/A'}</td>
                <td>${labor.gioi_tinh || 'N/A'}</td>
                <td>${labor.thuong_tru || 'N/A'}</td>
                <td>${labor.tam_tru || 'Không'}</td>
                <td>${labor.doi_tuong_uu_tien || 'Không'}</td>
                <td>${labor.trinh_do_pho_thong || 'N/A'}</td>
                <td>${labor.trinh_do_chuyen_mon || 'N/A'}</td>
                <td>${labor.chuyen_nganh_dao_tao || 'Không'}</td>
                <td>${labor.tinh_trang_hoat_dong || 'N/A'}</td>
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
                            <li><a class="dropdown-item" href="/Employees/Show/${labor.id}">Xem</a></li>
                            <li><a class="dropdown-item" href="/Employees/Edit/${labor.id}">Sửa</a></li>
                            <li><a class="dropdown-item text-danger" href="#" onclick="deleteEmployee(${labor.id})">Xóa</a></li>
                        </ul>
                    </div>
                </td>
            </tr>
        `);
    });
}

function applyCustomFilter() {
    const filterData = {
        tinhTrangHoatDong: $('#tinh_trang_hoat_dong').val(),
        trinhDoChuyenMon: $('#trinh_do_chuyen_mon').val(),
        gioiTinh: $('#gioi_tinh').val(),
        doTuoi: $('#do_tuoi').val(),
        tinhTp: $('#tinh_tp').val(),
        doiTuongUuTien: $('#doi_tuong_uu_tien').val(),
        tamTru: $('#tam_tru').val(),
        trinhDoPhoThong: $('#trinh_do_pho_thong').val(),
        chuyenNganhDaoTao: $('#chuyen_nganh_dao_tao').val(),
        viTheViecLam: $('#vi_the_viec_lam').val(),
        congViec: $('#cong_viec').val(),
        noiLamViec: $('#noi_lam_viec').val(),
        thoiGianThatNghiep: $('#thoi_gian_that_nghiep').val(),
        nhuCauViecLam: $('#nhu_cau_viec_lam').val(),
        trinhDoDaoTaoHienTai: $('#trinh_do_dao_tao_hien_tai').val(),
        chuyenNganhHienTai: $('#chuyen_nganh_hien_tai').val(),
        thoiGianTotNghiep: $('#thoi_gian_tot_nghiep').val()
    };

    // Kiểm tra xem có filter nào được chọn không
    const hasFilter = Object.values(filterData).some(value => value && value !== '');
    
    if (hasFilter) {
        // Gọi API filter
        loadEmployeesWithFilter(filterData);
    } else {
        // Load tất cả dữ liệu
        loadEmployees();
    }
}

function deleteEmployee(id) {
    if (confirm('Bạn có chắc chắn muốn xóa người lao động này?')) {
        $.ajax({
            url: `/Employees/Delete/${id}`,
            type: 'POST',
            success: function(response) {
                if (response.success) {
                    loadEmployees(); // Reload dữ liệu
                    alert('Xóa thành công!');
                } else {
                    alert('Lỗi khi xóa: ' + response.message);
                }
            },
            error: function() {
                alert('Lỗi khi xóa người lao động');
            }
        });
    }
}

$(document).ready(function () {
    // Load dữ liệu từ server
    loadEmployees();

    $('#resetFilter').click(function () {
        $('#filterForm').trigger('reset');
        loadEmployees(); // Load lại tất cả dữ liệu
    })

    $('#applyFilter').click(function () {
        applyCustomFilter();
        const modal = bootstrap.Modal.getOrCreateInstance(document.getElementById('filterModal'));
        modal.hide();
    })
})
