
// Demo chuyển user chat
const users = [
    {
        id: 1,
        name: "Nguyễn Văn A",
        avatar: "../../img/undraw_profile_1.svg",
        status: "Online",
        messages: [
            {from: "other", text: "Xin chào, bạn cần hỗ trợ gì?", time: "08:01 25/07/2025"},
            {from: "user", text: "Tôi muốn hỏi về báo cáo tháng này.", time: "08:02 25/07/2025"}
        ]
    },
    {
        id: 2,
        name: "Trần Thị B",
        avatar: "../../img/undraw_profile_2.svg",
        status: "Offline",
        messages: [
            {from: "other", text: "Chào bạn, tôi sẽ phản hồi khi online.", time: "09:00 24/07/2025"}
        ]
    },
    {
        id: 3,
        name: "Phạm Văn C",
        avatar: "../../img/undraw_profile_3.svg",
        status: "Online",
        messages: [
            {from: "other", text: "Bạn cần hỗ trợ gì về hệ thống?", time: "10:15 23/07/2025"}
        ]
    }
];
let currentUser = 1;

function renderChat(userId) {
    const user = users.find(u => u.id === userId);
    if (!user) return;
    document.getElementById('chatAvatar').src = user.avatar;
    document.getElementById('chatName').textContent = user.name;
    document.getElementById('chatStatus').textContent = user.status;
    document.getElementById('chatStatus').className = 'status ' + (user.status === 'Online' ? 'text-success' : 'text-secondary');
    const chatMessages = document.getElementById('chatMessages');
    chatMessages.innerHTML = '';
    user.messages.forEach(msg => {
        const div = document.createElement('div');
        div.className = 'chat-message ' + msg.from;
        div.innerHTML = `
                <img src="${msg.from === 'user' ? '../../img/undraw_profile.svg' : user.avatar}" class="avatar" alt="${msg.from}">
                <div>
                    <div class="bubble">${msg.text}</div>
                    <div class="meta${msg.from === 'user' ? ' text-right' : ''}">${msg.time}</div>
                </div>
            `;
        chatMessages.appendChild(div);
    });
    chatMessages.scrollTop = chatMessages.scrollHeight;
}

document.querySelectorAll('#userList .list-group-item').forEach(item => {
    item.addEventListener('click', function() {
        document.querySelectorAll('#userList .list-group-item').forEach(i => i.classList.remove('active'));
        this.classList.add('active');
        currentUser = parseInt(this.getAttribute('data-user'));
        renderChat(currentUser);
    });
});

document.getElementById('chatForm').addEventListener('submit', function(e) {
    e.preventDefault();
    const input = document.getElementById('chatInput');
    const value = input.value.trim();
    if (value) {
        const now = new Date();
        const time = now.getHours().toString().padStart(2, '0') + ':' +
            now.getMinutes().toString().padStart(2, '0') + ' ' +
            now.getDate().toString().padStart(2, '0') + '/' +
            (now.getMonth() + 1).toString().padStart(2, '0') + '/' +
            now.getFullYear();
        const user = users.find(u => u.id === currentUser);
        user.messages.push({from: "user", text: value, time: time});
        renderChat(currentUser);
        input.value = '';
    }
});

// Khởi tạo giao diện chat đầu tiên
renderChat(currentUser);
