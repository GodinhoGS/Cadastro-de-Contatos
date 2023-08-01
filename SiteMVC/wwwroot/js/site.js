// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let table = new DataTable('#table-contact');


$('.close-alert').click(function () {
    $('.alert').hide('hide');
});


function maskPhone(selector) {
    const phoneInput = document.querySelector(selector);

    phoneInput.addEventListener('input', (e) => {
        let phone = phoneMask(e.target.value);
        e.target.value = phone;
    });
} 

function phoneMask(phone) {

    // Remove non-digits
    phone = phone.replace(/\D/g, '');

    // Check length
    if (phone.length !== 11) {
        return phone;
    }

    // Format as (31) 99999-9999 
    phone = '(' + phone.substring(0, 2) + ') ' + phone.substring(2, 7) + '-' + phone.substring(7);

    return phone;

}