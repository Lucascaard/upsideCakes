/*using Microsoft.AspNetCore.Mvc;
using upsideCakes.Models;
using upsideCakes.Data;
using Microsoft.EntityFrameworkCore;


namespace upsideCakes.Controllers;
    [ApiController]
    [Route("[productcontroller]")] 

    public class ProductController : ControllerBase
    {
        private ProductDbContext _dbContext;
    public ProductController(ProductDbContext dbContext)
    { 
        _dbContext = dbContext;
    }

    //CREATE
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult> Create(Product product)
    {
        await _dbContext.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return Created("", product);
    }

    //READ
    [HttpGet]
    [Route("read")]
    public async Task<ActionResult<IEnumerable<Product>>> Read()
    {
        return await _dbContext.Product.ToListAsync();
    }

    [HttpGet]
    [Route("read/{id}")]
    public async Task<ActionResult<Product>> ReadForID(int id)
    {
        var productTemp = await _dbContext.Product.FindAsync(id);
        if (productTemp != null) return NotFound();
        return Ok(productTemp);
    }

    [HttpPut]
    [Route("update")]

    public async Task<ActionResult> Update(Product product)
    {
        if (_dbContext.Product is null) return NotFound();
        if (await _dbContext.Product.FindAsync(product.Id) is null) return NotFound();
        _dbContext.Update(product);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch]
    [Route("updatePrice/{id}")]
    public async Task<ActionResult> UpdatePrice(int id, [FromForm] float price)
    {
        var productTemp = await _dbContext.Product.FindAsync(id);
        if (productTemp is null) return NotFound();
        productTemp._price = price;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<ActionResult> Delete(int id)
    {
        if (_dbContext.Product is null) return NotFound();
        var productTemp = await _dbContext.Product.FindAsync(id);
        if (productTemp is null) return NotFound();
        _dbContext.Product.Remove(productTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}

*/