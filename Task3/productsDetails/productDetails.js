/** @format */
debugger;
var id = localStorage.getItem("productId");

async function getProducts() {
  let url = `https://localhost:44327/api/Products/Product/${id}`;

  let request = await fetch(url);

  let data = await request.json();
  let cards = document.getElementById("conteainer");

  cards.innerHTML = `
         <div class="card" style="width: 18rem;">
            <img src="..." class="card-img-top" alt=${data.productImage};
            <div class="card-body">
                <h5 class="card-title">${data.productName}</h5>
                <h4 ">Price: ${data.price}</h4>
                <p>${data.description}</p>
            </div>
        </div>
        <br>
      `;

  console.log(data);
}

getProducts();
