(function () {
    "use strict";

    var STORAGE_KEY = "portfolio-theme";

    function applyTheme(theme) {
        document.documentElement.setAttribute("data-theme", theme);
    }

    function initTheme() {
        var saved = localStorage.getItem(STORAGE_KEY);
        if (saved) applyTheme(saved);

        document.addEventListener("click", function (e) {
            var toggle = e.target.closest("[data-theme-toggle]");
            if (!toggle) return;
            var current = document.documentElement.getAttribute("data-theme") ||
                (window.matchMedia("(prefers-color-scheme: dark)").matches ? "dark" : "light");
            var next = current === "dark" ? "light" : "dark";
            applyTheme(next);
            localStorage.setItem(STORAGE_KEY, next);
        });
    }

    function initScrollReveal() {
        var targets = document.querySelectorAll(".reveal");
        if (!targets.length) return;

        if (!("IntersectionObserver" in window)) {
            targets.forEach(function (el) { el.classList.add("in-view"); });
            return;
        }

        var observer = new IntersectionObserver(function (entries) {
            entries.forEach(function (entry) {
                if (entry.isIntersecting) {
                    entry.target.classList.add("in-view");
                    observer.unobserve(entry.target);
                }
            });
        }, { threshold: 0.15, rootMargin: "0px 0px -40px 0px" });

        targets.forEach(function (el) { observer.observe(el); });
    }

    // Re-run scroll reveal whenever Blazor re-renders new content into the DOM.
    function watchForNewReveals() {
        var mo = new MutationObserver(function () { initScrollReveal(); });
        mo.observe(document.body, { childList: true, subtree: true });
    }

    document.addEventListener("DOMContentLoaded", function () {
        initTheme();
        initScrollReveal();
        watchForNewReveals();
    });
})();
