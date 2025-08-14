 async function solution() {
    const mainEl = document.getElementById('main');

    const articlesRes = await fetch('http://localhost:3030/jsonstore/advanced/articles/list');
    const articlesData = await articlesRes.json();
    const articlesArr = Object.values(articlesData);
    
    articlesArr.forEach(article => {
        const accordionDivEl = document.createElement('div');
        accordionDivEl.classList.add('accordion');

        const infoDivEl = document.createElement('div');
        infoDivEl.classList.add('extra');
        infoDivEl.style.display = 'none';

        const infoPEl = document.createElement('p');
        infoDivEl.appendChild(infoPEl);

        const headDivEl = document.createElement('div'); 
        headDivEl.classList.add('head');

        const spanTitleEl = document.createElement('span');
        spanTitleEl.textContent = article.title;

        const buttonEl = document.createElement('button');
        buttonEl.classList.add('button');
        buttonEl.id = article._id;
        buttonEl.textContent = 'More';
        buttonEl.addEventListener('click', handleBtnFunctionality);

        headDivEl.appendChild(spanTitleEl);
        headDivEl.appendChild(buttonEl);

        accordionDivEl.appendChild(headDivEl);

        mainEl.appendChild(accordionDivEl);
        accordionDivEl.appendChild(infoDivEl);

        async function handleBtnFunctionality() {
            if (buttonEl.textContent === 'More') {
                buttonEl.textContent = 'Less';
                infoDivEl.style.display = 'block';

                const articleInfoRes = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${buttonEl.id}`);
                const articleInfoData = await articleInfoRes.json();
                
                infoPEl.textContent = articleInfoData.content;

            } else {
                buttonEl.textContent = 'More';
                infoDivEl.style.display = 'none'
            }
        }
    })
}

solution();