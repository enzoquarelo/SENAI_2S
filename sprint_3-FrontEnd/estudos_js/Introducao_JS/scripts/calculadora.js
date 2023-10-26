function calculate() {

    let valueN1 = document.getElementById('n1');
    let valueN2 = document.getElementById('n2');
    var typeFunctionSelect = document.getElementById('selectCalc');
    var resultCalc = document.getElementById('result');

    var n1 = parseFloat(valueN1.value);
    var n2 = parseFloat(valueN2.value);

    var selectedOperation = typeFunctionSelect.value;

    if (selectedOperation === 'value1') {

        const result = n1 + n2;
        alert(`Resultado: ${result}`);

    } else if (selectedOperation === 'value2') {

        const result = n1 - n2;
        alert(`Resultado: ${result}`);

    } else if (selectedOperation === 'value3') {

        const result = n1 * n2;
        alert(`Resultado: ${result}`);

    }
    else if (selectedOperation === 'value4') {

        const result = n1 / n2;
        alert(`Resultado: ${result}`);

    }
    else
    {
        alert('Operação inválida!')
    }
}