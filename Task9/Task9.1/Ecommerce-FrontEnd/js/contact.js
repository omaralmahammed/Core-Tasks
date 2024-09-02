/** @format */

const contactForm = document.getElementById("contactForm");

contactForm.addEventListener("submit", async (event) => {
  event.preventDefault();
  const contactInfo = new FormData(contactForm);

  fetch(`https://localhost:44398/api/Users/Contact`, {
    method: "POST",
    body: contactInfo,
  });

  alert("Your Feedback was sent successfully!");
  window.location.reload();
});
