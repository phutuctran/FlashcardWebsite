window.addEventListener('beforeunload', function () {
    var lastScrollPosition = document.documentElement.scrollTop;
    localStorage.setItem('lastScrollPosition', lastScrollPosition);
});

window.addEventListener('DOMContentLoaded', function () {
    var lastScrollPosition = localStorage.getItem('lastScrollPosition');
    if (lastScrollPosition) {
        window.scroll(0, lastScrollPosition);
    }
});