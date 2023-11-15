async function getAllProduct() {
    try {
        const res = await fetch('api/product')
        if (!res.ok)
            throw new Error("failed")
        const products = await res.json()

        if (products)
            products.map(p =>
               drawProduct(p)
            );
            
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
    clone.querySelector("h1").innerhtml = p.name
    clone.querySelector(".price").innerhtml = p.price
    clone.querySelector(".description").innerhtml = p.des
    //clone.querySelector(".button").addEventListener(click, addToCart(p))


    const list = document.getElementById('PoductList');
    list.appendChild(clone);
} 

async function addToCart(p) {
    sessionStorage.setItem('product', p)
}

async function showCategory(c) {
    const temp = document.getElementById('temp-category')
    const clone = temp.content.cloneNode(true)//chack
    clone.querySelector("label").for = c.name;
    clone.querySelector("input").value = c.name;
    clone.querySelector("input").id = c.categoryId;
    clone.querySelector(".OptionName").innerText = c.name.trim()
    const list = document.getElementById('categoryList');
    list.appendChild(clone);
}

async function filterProduct() {

}