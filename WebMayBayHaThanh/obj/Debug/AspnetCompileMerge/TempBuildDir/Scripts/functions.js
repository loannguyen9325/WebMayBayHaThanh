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