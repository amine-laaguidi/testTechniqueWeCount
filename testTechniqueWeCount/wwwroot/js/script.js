$(document).ready(function () {
    // Animation du texte
    const animationText = $('.animation');
    const textToAnimate = "Bienvenue sur notre portail de candidature en ligne. Nous sommes ravis de vous accueillir et de vous offrir l'opportunité de rejoindre notre équipe exceptionnelle. Découvrez comment vous pouvez faire partie de notre entreprise et contribuer à notre succès.";
    let index = 0;
    function animateText() {
        if (index <= textToAnimate.length) {
            $('#typing').text(textToAnimate.slice(0, index));
            index++; index++; index++; index++; index++;
            setTimeout(animateText, 50);
        } else {
            animationText.addClass('show-animation');
        }
    }
    animateText();

    // Afficher le menu de la version mobile
    $(".btn-sidebar").click(function () {
        $(".navigate").animate({ left: '0vw' });
    });

    // Masquer le menu de la version mobil
    $(".hide").click(function () {
        if ($(".navigate").css("left") === "0px") {
            $('.navigate').animate({ left: '-60vw' })
        }
    });

    // Masquer le menu de la version mobile en cliquant sur un élément du menu.
    $(".content").click(function () {
        if ($(".navigate").css("left") === "0px") {
            $('.navigate').animate({ left: '-60vw' })
        }
    });
    // Masquer la notification d'erreur aprés 5 secondes
    var err = $("#error");
    if (err.length > 0) {
        setInterval(function () {
            err.css({ opacity: 0, visibility: "hidden" });
        }, 5000);
    }
    // Masquer la notification de succession aprés 5 secondes
    var suc = $("#success");
    if (suc.length > 0) {
        setInterval(function () {
            suc.css({ opacity: 0, visibility: "hidden" });
        }, 5000);
    }

});