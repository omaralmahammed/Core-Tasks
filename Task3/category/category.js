/** @format */

async function getAllCtegory() {
  let url = "https://localhost:44327/api/Categories/AllCategories";
  let request = await fetch(url);

  let data = await request.json();
  let cards = document.getElementById("conteainer");

  data.forEach((category) => {
    cards.innerHTML += `
        <div class="card" style="width: 18rem;">
    <img class="card-img-top" src="..." alt="${category.categoryImage} (image not found)">
    <div class="card-body">
        <h5 class="card-title">${category.categoryName}</h5>
        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
        <a href="../product/product.html" onClick="setLocalStorage(${category.categoryId})" class="btn btn-primary">Show Products</a>
    </div>
    </div>
    `;
  });

  console.log(data);
}

getAllCtegory();

function setLocalStorage(id) {
  localStorage.categoryId = id;
}
