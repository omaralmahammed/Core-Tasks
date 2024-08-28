/** @format */

var id = localStorage.getItem("categoryId");

if (id == "null") {
  var url = `https://localhost:44312/api/Products/AllProducts`;
} else {
  var url = `https://localhost:44312/api/Products/getProductByCategoryId/${id}`;
}

async function getProducts() {
  let request = await fetch(url);

  let data = await request.json();
  let cards = document.getElementById("cardContainer");

  data.forEach((product) => {
    cards.innerHTML += `
    <div class="col-md-4 mb-4">
      <div class="card">
        <img class="card-img-top" src="/Day5-BackEnd/Day5-BackEnd/Images/${product.productImage}" alt="Card image cap 1" />
        <div class="card-body">
          <h5 class="card-title">${product.productName}</h5>
          <h6> Price: ${product.price}</h6>
          <p class="card-text">
            ${product.description}
          </p>
          <a href="/Day5-FrontEnd/Products/EditProduct.html" onClick="setLocalStorage(${product.productId})" class="btn btn-primary">Edit</a> 
          <a href="/Day5-FrontEnd/Products/ProductDetails.html" onClick="setLocalStorage(${product.productId})" class="btn btn-primary">Details</a> 
          </div>
      </div>
    </div>
      `;
  });
}

getProducts();

function setLocalStorage(id) {
  localStorage.productId = id;
}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

const formRef = document.getElementById("productForm");

formRef.addEventListener("submit", (event) => {
  event.preventDefault();

  const formData = new FormData(formRef);

  formData.append("CategoryId", id);

  console.log(formData);

  fetch("https://localhost:44312/api/Products/AddProduct", {
    method: "POST",
    body: formData,
  })
    .then((res) => res.json())
    .then((formData) => console.log(formData))
    .catch((error) => console.log(error));
});
