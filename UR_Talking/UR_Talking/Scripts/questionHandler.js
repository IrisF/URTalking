var onButtonClick = function (ev) {
    var input = $('input[type=search]').val();

    ev.preventDefault();

    if(input){
        renderQuestion(input);
        sendQuestion(input);
    } else {
        alert("Gib etwas ein!!");
    }
},
    sendQuestion = function (question) {
        $.ajax({
            url: "api/values",
            type: "POST",
            data: { '': question },
            success: onAnswerSuccess,
            error: onAnswerError
        });
    },
    onAnswerSuccess = function (response) {
        checkIfResponseIsLink(response);
        console.log(response);
    },

    checkIfResponseIsLink = function (response) {
        if (response.type == "Link") {
            setUrlOfIFrame(response.value);
            renderAnswerIfLink(response);
        } else {
            renderAnswer(response);
        }
    },

    onAnswerError = function (err) {
        console.log(err);
    },
    renderAnswer = function (answer) {
        var answerLi = $('<li><strong>' + "Elise: " + '</strong>' + answer + '</li>');
        attachListElement(answerLi);
    },

    attachListElement = function (answerLi) {
        $('#chatHistory').append(answerLi);
        if ($('.chat_box ul li').length > 8) {
            var height = $('.chat_box')[0].scrollHeight;
            $('.chat_box').scrollTop(height);
        }
        $('input[type=search]').val("");
    },

    renderAnswerIfLink = function (answer) {
        console.log("renderAnswerIfLink");
        var button = setupButton(answer);
        var answerLi = $('<li><strong>' + "Elise: " + '</strong>' + answer + '</li>');
        answerLi.append(button);
        attachListElement(answerLi);
        setUrlOfIFrame(answer);
    },

    setupButton = function (answer) {
        var button= $('<button type="button" name="load" data-content="' + answer + '" style="width:30px; margin-left:5px;" class="glyphicon glyphicon-refresh"></button>');
        button.click(setUrlOnButtonClick);
        return button;
    },

    setUrlOnButtonClick = function (ev) {
        var url = $(ev.currentTarget).data('content');
        setUrlOfIFrame(url);
    },

    setUrlOfIFrame = function (url) {
        $('#iframe').removeClass('invisible');
        $('#iframe').attr('src', url);
    },

    setIFrameInvisible = function () {
        $('#iframe').addClass('invisible');
    },

    renderQuestion = function (question) {
        var user = $('<strong>Du: </strong>'),
            questionLi = $('<li><strong>' + "Du: " + '</strong>' + question + '</li>');
        $('#chatHistory').append(questionLi);
    };

(function () {
    $('button[type=submit]').click(onButtonClick);
}());
