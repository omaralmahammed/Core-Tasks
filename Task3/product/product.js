/** @format */

var id = localStorage.getItem("categoryId");
debugger;
if (id == "null") {
  var url = `https://localhost:44327/api/Products/AllProducts`;
} else {
  var url = `https://localhost:44327/api/Categories/productsByCategoryId/${id}`;
}

async function getProducts() {
  let request = await fetch(url);

  let data = await request.json();
  let cards = document.getElementById("conteainer");

  data.forEach((products) => {
    cards.innerHTML += `
         <div class="card" style="width: 18rem;">
            <img src="..." class="card-img-top" alt=${products.productImage};
            <div class="card-body">
                <h5 class="card-title">${products.productName}</h5>
                <a href="../productsDetails/productDetails.html"  onclick="setLocalStorage(${products.productId})" class="btn btn-primary">Show Details</a>
            </div>
        </div>
        <br>
      `;
  });

  console.log(data);
}

getProducts();

function setLocalStorage(id) {
  localStorage.productId = id;
}
