var q = document.getElementsByTagName('h2');
q[0].style.color = 'yellow';
q[0].addEventListener('click', OnClick);

function OnClick() {
    alert('You just clicked h2');

}