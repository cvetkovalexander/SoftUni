document.addEventListener('DOMContentLoaded', solve);

// function solve() {
//     const firstQuestionEl = document.querySelector('.question');
//     const secondQuestionEl = document.querySelector('.question:nth-of-type(2)');
//     const thirdQuestionEl = document.querySelector('.question:nth-of-type(3)');
//     const resEl = document.querySelector('#results');

//     let rightAnswers = 0;

//     const firstQuestionAnswers = firstQuestionEl.querySelectorAll('.quiz-answer');
    
//     firstQuestionAnswers[0].addEventListener('click', rightAnswer);
//     firstQuestionAnswers.forEach(el => el.addEventListener('click', function() {
//         firstQuestionEl.classList.add('hidden')
//         secondQuestionEl.classList.remove('hidden');
//     }));

//     const secondQuestionAnswers = secondQuestionEl.querySelectorAll('.quiz-answer');

//     secondQuestionAnswers[1].addEventListener('click', rightAnswer);
//     secondQuestionAnswers.forEach(el => el.addEventListener('click', function() {
//         secondQuestionEl.classList.add('hidden');
//         thirdQuestionEl.classList.remove('hidden');
//     }));

//     const thirdQuestionAnswers = thirdQuestionEl.querySelectorAll('.quiz-answer');

//     thirdQuestionAnswers[0].addEventListener('click', rightAnswer);
//     thirdQuestionAnswers.forEach(el => el.addEventListener('click', function() {
//         thirdQuestionEl.classList.add('hidden');
//         if (rightAnswers === 3) {
//         resEl.textContent = `You are recognized as top JavaScript fan!`;
//         } else if (rightAnswers === 1) {
//             resEl.textContent = `You have ${rightAnswers} right answer`;
//         } else {
//             resEl.textContent = `You have ${rightAnswers} right answers`;
//         }
//     }));
    
//     function rightAnswer(e) {
//       rightAnswers++;
//     }
// }

function solve() {
    const allQuestionEls = document.querySelectorAll('.question');
    const allAnswerEls = document.querySelectorAll('.quiz-answer');
    const resEl = document.querySelector('#results');

    const rightAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
    let currentQuestionIndex = 0;
    let rightAnswersCount = 0;

    allAnswerEls.forEach(el => el.addEventListener('click', handleAnswerEvent));

    function handleAnswerEvent(e) {
        const chosenAnswer = e.target.textContent;

        if (chosenAnswer === rightAnswers[currentQuestionIndex]) {
            rightAnswersCount++;
        }

        const sectionEl = allQuestionEls[currentQuestionIndex];
        sectionEl.classList.add('hidden');

        currentQuestionIndex++;

        if (currentQuestionIndex === allQuestionEls.length) {

            if (rightAnswersCount === 3) {
            resEl.textContent = `You are recognized as top JavaScript fan!`;
            } else if (rightAnswersCount === 1) {
                resEl.textContent = `You have ${rightAnswersCount} right answer`;
            } else {
                resEl.textContent = `You have ${rightAnswersCount} right answers`;
            }  

            return;
        }

        const newSectionEl = allQuestionEls[currentQuestionIndex];
        newSectionEl.classList.remove('hidden');
    }
}