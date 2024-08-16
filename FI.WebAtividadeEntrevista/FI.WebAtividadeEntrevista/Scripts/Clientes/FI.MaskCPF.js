
/*$(document).ready(function () {
    $("#CPF").inputmask("mask", { "mask": "999.999.999-99" }, { reverse: true });
});*/

const inputCPF = $("#CPF");

inputCPF.addEventListener('keypress', () => {
    let inputCPFlength = inputCPF.value.length;
    console.log('pegou');

    if (inputCPFlength === 3 || inputCPFlength === 7) {
        inputCPF.value += '.';

    } else if (inputCPFlength === 11) {
    inputCPF.value += '-'}



});