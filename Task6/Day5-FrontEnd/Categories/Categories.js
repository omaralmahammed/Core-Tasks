/** @format */

async function getAllCategory() {
  let url = "https://localhost:44312/api/Categories/AllCategories";

  let request = await fetch(url);

  let data = await request.json();
  let cardContainer = document.getElementById("cardContainer");

  console.log(data);

  data.forEach((category) => {
    cardContainer.innerHTML += `
    <div class="col-md-4 mb-4">
      <div class="card">
        <img class="card-img-top" src="/Day5-BackEnd/Day5-BackEnd/Images/${category.categoryImage}" alt="Card image cap 1" />
        <div class="card-body">
          <h5 class="card-title">${category.categoryName}</h5>
          <p class="card-text">
            ${category.categoryDescription}
          </p>
          <a href="/Day5-FrontEnd/Products/Products.html" onClick="setLocalStorage(${category.categoryId})" class="btn btn-primary">Show all products</a> 
          <a href="/Day5-FrontEnd/Categories/EditCategory.html" onClick="setLocalStorage(${category.categoryId})" class="btn btn-secondary">Edit</a> 
        </div>
      </div>
    </div>
      `;
  });
}

function setLocalStorage(id) {
  localStorage.categoryId = id;
}

getAllCategory();

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

const formRef = document.getElementById("categoryForm");
console.log(formRef);
formRef.addEventListener("submit", (event) => {
  event.preventDefault();

  const formData = new FormData(formRef);
  console.log(formData);
  console.log(formData.get("CategoryName"));

  fetch("https://localhost:44312/api/Categories/AddCategory", {
    method: "POST",
    body: formData,
  });
});
