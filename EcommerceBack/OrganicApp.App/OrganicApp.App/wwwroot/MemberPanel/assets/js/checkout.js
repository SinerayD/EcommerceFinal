
        document.addEventListener('DOMContentLoaded', function() {
        const form = document.querySelector('.checkout__form form');

        form.addEventListener('submit', function(event) {
            let isValid = true;

        // Check First Name
        const firstName = document.querySelector('input[name="firstName"]');
        if (!firstName.value.trim()) {
            isValid = false;
        alert('Please enter your First Name.');
            }

        // Check Last Name
        const lastName = document.querySelector('input[name="lastName"]');
        if (!lastName.value.trim()) {
            isValid = false;
        alert('Please enter your Last Name.');
            }

        // Check Country
        const country = document.querySelector('input[name="country"]');
        if (!country.value.trim()) {
            isValid = false;
        alert('Please enter your Country.');
            }

        // Check Address
        const address = document.querySelector('input[name="address"]');
        if (!address.value.trim()) {
            isValid = false;
        alert('Please enter your Address.');
            }

        // Check Town/City
        const city = document.querySelector('input[name="city"]');
        if (!city.value.trim()) {
            isValid = false;
        alert('Please enter your Town/City.');
            }

        // Check Country/State
        const state = document.querySelector('input[name="state"]');
        if (!state.value.trim()) {
            isValid = false;
        alert('Please enter your Country/State.');
            }

        // Check Postcode/ZIP
        const postcode = document.querySelector('input[name="postcode"]');
        if (!postcode.value.trim()) {
            isValid = false;
        alert('Please enter your Postcode/ZIP.');
            }

        // Check Phone
        const phone = document.querySelector('input[name="phone"]');
        if (!phone.value.trim()) {
            isValid = false;
        alert('Please enter your Phone.');
            }

        // Check Email
        const email = document.querySelector('input[name="email"]');
        if (!email.value.trim() || !isValidEmail(email.value)) {
            isValid = false;
        alert('Please enter a valid Email.');
            }

        if (!isValid) {
            event.preventDefault(); // Prevent form submission if there are validation errors
            }
        });

        function isValidEmail(email) {
            const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
        }
    });
 
