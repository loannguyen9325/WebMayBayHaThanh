function ShowAlert(title, msg, type){
    $.toast({
        heading: title,
        text: msg,
        icon: type,
        showHideTransition: 'slide',
        position: 'top-right',
        loader: true
    });
}

function ShowAlert_Home(title, msg, type) {
    $.toast({
        heading: title,
        text: msg,
        icon: type,
        showHideTransition: 'slide',
        position: 'top-center',
        loader: true
    });
}