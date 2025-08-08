// Demo lọc hoạt động
const allActivities = [
    {
        type: "login",
        icon: "fa-sign-in-alt",
        color: "bg-success",
        title: "Đăng nhập hệ thống",
        time: "08:00 25/07/2025"
    },
    {
        type: "edit",
        icon: "fa-edit",
        color: "bg-info",
        title: "Cập nhật thông tin cá nhân",
        time: "09:15 24/07/2025"
    },
    {
        type: "report",
        icon: "fa-file-alt",
        color: "bg-warning",
        title: "Tạo báo cáo mới",
        time: "10:30 23/07/2025"
    },
    {
        type: "delete",
        icon: "fa-trash",
        color: "bg-danger",
        title: "Xóa tài liệu",
        time: "11:00 22/07/2025"
    }
];

function renderActivities(type, date) {
    const list = document.getElementById('activityList');
    list.innerHTML = '';
    let filtered = allActivities;
    if (type) filtered = filtered.filter(a => a.type === type);
    if (date) filtered = filtered.filter(a => a.time.endsWith(date.split('-').reverse().join('/')));
    if (filtered.length === 0) {
        list.innerHTML = '<li class="text-center text-muted py-4">Không có hoạt động nào phù hợp.</li>';
        return;
    }
    filtered.forEach(a => {
        list.innerHTML += `
                <li>
                    <div class="activity-icon ${a.color} text-white"><i class="fas ${a.icon}"></i></div>
                    <div class="activity-content">
                        <div class="activity-title">${a.title}</div>
                        <div class="activity-time">${a.time}</div>
                    </div>
                </li>
            `;
    });
}

document.getElementById('filterBtn').onclick = function () {
    const type = document.getElementById('activityType').value;
    const date = document.getElementById('activityDate').value;
    renderActivities(type, date);
};

// Khởi tạo danh sách hoạt động ban đầu
renderActivities();
