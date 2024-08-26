/** @format */
var id = localStorage.getItem("productId");

async function getProducts() {
  let url = `https://localhost:44327/api/Products/ProductById/${id}`;

  let request = await fetch(url);

  let data = await request.json();
  let cards = document.getElementById("conteainer");

  cards.innerHTML = `
         <div class="card" style="width: 18rem;">
            <img src="..." class="card-img-top" alt=${data[0].productImage};
            <div class="card-body">
                <h5 class="card-title">${data[0].productName}</h5>
                <h4 ">Price: ${data[0].price}</h4>
                <p>${data[0].description}</p>
            </div>
        </div>
        <br>
      `;

  console.log(data);
}

getProducts();
