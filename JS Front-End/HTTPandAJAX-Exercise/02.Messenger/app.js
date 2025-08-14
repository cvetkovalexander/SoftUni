const authorInputEl = document.querySelector('input[name="author"]');
const contentInputEl = document.querySelector('input[name="content"]');
const messagesTextarea = document.getElementById('messages');
const submitInputEl = document.getElementById('submit');
const refreshInputEl = document.getElementById('refresh');

function attachEvents() {
    submitInputEl.addEventListener('click', handleSubmitMessage);
    refreshInputEl.addEventListener('click', handleRefreshMessages);
}

attachEvents();

async function handleSubmitMessage() {
    const author = authorInputEl.value.trim();
    const content = contentInputEl.value.trim();

    const message =  { author, content };

    const createRes = await fetch('http://localhost:3030/jsonstore/messenger', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(message)
    });
}

async function handleRefreshMessages() {
    const allMessagesRes = await fetch('http://localhost:3030/jsonstore/messenger');
    const allMessagesData = await allMessagesRes.json();
    
    const messagesArr = Object.values(allMessagesData);
    
    let messages = [];
    messagesArr.forEach(msg => {
        messages.push(`${msg.author}: ${msg.content}`);
    });

    messagesTextarea.textContent = messages.join('\n');
}