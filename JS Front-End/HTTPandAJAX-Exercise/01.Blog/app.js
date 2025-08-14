const loadPostsBtn = document.getElementById('btnLoadPosts');
const viewPostBtn = document.getElementById('btnViewPost');
const postsSelectEl = document.getElementById('posts');
const postTitleEl = document.getElementById('post-title');
const postBodyEl = document.getElementById('post-body');
const commentsUlEl = document.getElementById('post-comments');

function attachEvents() {
    loadPostsBtn.addEventListener('click', handleLoadPosts);
    viewPostBtn.addEventListener('click', handleViewPosts);
}

function handleLoadPosts() {
    fetch ('http://localhost:3030/jsonstore/blog/posts')
        .then(res => res.json())
        .then(postsObj => {
            const postsEntries = Object.entries(postsObj);
            for (const postObj of postsEntries) {
                const optionEl = document.createElement('option');
                optionEl.value = postObj[0];
                optionEl.textContent = postObj[1].title;
                postsSelectEl.appendChild(optionEl);
            }
        })
}

async function handleViewPosts() {
    const allPostsRes = await fetch('http://localhost:3030/jsonstore/blog/posts');
    const allPostsData = await allPostsRes.json();
    const allPostsDataEntries = Object.entries(allPostsData);

    const search = postsSelectEl.value;
    const selectedPost = allPostsDataEntries.find(post => post[1].id === search);
    const selectedPostId = selectedPost[1].id;
    postTitleEl.textContent = selectedPost[1].title;
    postBodyEl.textContent = selectedPost[1].body;

    const allComentsRes = await fetch('http://localhost:3030/jsonstore/blog/comments');
    const allComentsData = await allComentsRes.json();
    const allComentsDataEntries = Object.entries(allComentsData);

    const selectedComments = allComentsDataEntries.filter(comment => comment[1].postId === selectedPostId);

    for (const [_, comment] of selectedComments) {
        const commentLiEl = document.createElement('li');
        commentLiEl.textContent = comment.text;
        commentsUlEl.appendChild(commentLiEl);
    }
}

attachEvents();