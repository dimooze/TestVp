$(function () {
    // Set username in welcome message.
    if (SecurityManager.username) {
        $('#status').text('Welcome, ' + SecurityManager.username + '!');

        $('#btnLogin').show();
        $('#btnLogout').hide();
        $('#logout').hide();

    }

    // Button click events.
    $('#btnLogin').click(function () {

        var password = $('#password').val();
        var email = $('#email').val();
        // Login as the user and create a token key.
        SecurityManager.generate(email, password);

        $.get('/MyApi/IsLoggedIn?email' + email + '&token=' + SecurityManager.generate(),

            function (data) {
                alert('Ok, logged in!');

                $('#btnLogin').hide();
                $('#btnLogout').show();
                $('#password').hide();
                $('#email').hide();
                $('#login').hide();
                $('#logout').show();

                $('#status').text('Welcome, ' + SecurityManager.username + '!');
            }).fail(function (error) {
                alert('HTTP Error ' + error.status)
            });


    });

    $('#btnLogout').click(function () {
        // Clear the token key and delete localStorage settings.
        SecurityManager.logout();

        alert('Ok, logged out!');

        $('#btnLogin').show();
        $('#btnLogout').hide();
        $('#password').show();
        $('#email').show();
        $('#login').show();
        $('#logout').hide();

        $('#status').text('Welcome!');
        $('#result').text('');
    });

    $('#btnSearch').click(function () {
        var query = $('#txtQuery').val();

        $.get('/MyApi/isLoggedIn?q=' + query + '&token=' + SecurityManager.generate(), function (data) {
            $("#result").append('<p>' + data + '</p>');
        }).fail(function (error) {
            $("#result").append('<p>' + "false" + '</p>');
        });
    });

});