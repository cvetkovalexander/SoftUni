function calc() {
    const a = document.getElementById('num1');
    const b = document.getElementById('num2');
    const res = document.getElementById('sum');

    res.value = Number(a.value) + Number(b.value);
}