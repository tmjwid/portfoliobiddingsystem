var quill = new Quill('#snow-container', {
    placeholder: 'Compose an epic...',
    theme: 'snow'
});

var form = document.querySelector('form');
form.onsubmit = function() {
    // Populate hidden form on submit
    var selector = document.getElementById('Description');
    selector.value = quill.root.innerHTML;
};

