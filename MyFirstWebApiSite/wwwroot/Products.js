async function getAllProduct(url) {
    try {
        const res = await fetch(url)
        if (!res.ok)
            throw new Error("failed")
        const products = await res.json()

        if (products)
        {
            document.getElementById('PoductList').replaceChildren([]);
            products.map(p =>
               drawProduct(p)
            );
        }
           
            
        else
            alert("not found product");

        //sessionStorage.setItem("currentUser", JSON.stringify(data))
    }
    catch (ex) {
        alert(ex.message)
    }
}

async function getAllCategory() {
    try {
        const res = await fetch('api/category')
        if (!res.ok)
            throw new Error("failed")
        const categories = await res.json()

        if (categories)
            categories.map(c =>
                showCategory(c)
            );

        else
            alert("not found product");

        //sessionStorage.setItem("currentUser", JSON.stringify(data))
    }
    catch (ex) {
        alert(ex.message)
    }
}
async function drawProduct(p) {
    const temp = document.getElementById('temp-card')
    const clone = temp.content.cloneNode(true)//chack
    clone.querySelector("img").src = "./pictures/" + p.image
    clone.querySelector("h1").innerText = p.name
    clone.querySelector(".price").innerText = p.price
    clone.querySelector(".description").innerText = p.des
    clone.querySelector("button").addEventListener('click', () => addToCart(JSON.stringify(p)))

    const list = document.getElementById('PoductList');
    
    list.appendChild(clone);
} 

async function addToCart(p) {

    sessionStorage.setItem('product', p)
}

async function showCategory(c) {
    const temp = document.getElementById('temp-category')
    const clone = temp.content.cloneNode(true)
    clone.querySelector("label").for = c.name;
    clone.querySelector("input").innerText = c.name;
    clone.querySelector("input").id = c.categoryId;
    clone.querySelector(".OptionName").innerText = c.name.trim()
    const list = document.getElementById('categoryList');
    list.appendChild(clone);
}

async function filterProducts() {
    let url = 'https://localhost:44383/api/product'
    let categories = [];
    let allCategoryOption = document.querySelectorAll('.opt');
    for (let i = 0; i < allCategoryOption.length; i++) {
        if (allCategoryOption[i].checked)
            categories.push(allCategoryOption[i].id)
    }
    let name = document.getElementById('nameSearch').value
    let minPrice = document.getElementById('minPrice').value
    let maxPrice = document.getElementById('maxPrice').value
    //clone.querySelector("button").addEventListener('click', () => addToCart(JSON.stringify(p)))

    if (name || categories || minPrice || maxPrice)
        url += '?'
    if (name)
        url += 'name=' + name
    if (minPrice)
        url += '&minPrice=' + minPrice
    if (maxPrice)
        url += '&maxPrice=' + maxPrice
    console.log(categories[1])
    if (categories)
    {
        for (let j = 0; j < categories.length; j++) {
            url += '&categoryIds=' + categories[j]
        }
    }
    getAllProduct(url)

    //https://localhost:44383/api/product?name=camera&minPrice=1000&maxPrice=2000&categoryIds=1&categoryIds=2
    //https://localhost:44383/api/product?categoryIds=1&categoryIds=2



}