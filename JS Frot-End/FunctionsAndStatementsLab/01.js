

function formatGrade(grade) {
    let gradeStr = `${grade.toFixed(2)}`;
    if (grade < 3) console.log(`Fail (2)`);
    else if (grade < 3.5) console.log(`Poor (${gradeStr})`);
    else if (grade < 4.5) console.log(`Good (${gradeStr})`);
    else if (grade < 5.5) console.log(`Very good (${gradeStr})`);
    else console.log(`Excellent (${gradeStr})`);
}