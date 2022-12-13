using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;

[Route("api/[controller]")]
[ApiController]

public class SuperHeroController : ControllerBase
{
    private static List<SuperHero> heroes = new List<SuperHero>
    {
        // new SuperHero
        // {
        //     Id = 1, Name = "Spider Man",
        //     FirstName = "Peter",
        //     LastName = "Parker",
        //     Place = "New York city"
        // }
    };
    
    private readonly DataContext _context;

    public SuperHeroController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> Get()
    {
        return Ok(await _context.SuperHeroes.ToListAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHero>> Get(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        
        if (hero == null)
        {
            return BadRequest("Heroi não encontrado");
        }
        
        return Ok(hero);
    }
    
    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
    {
        _context.SuperHeroes.Add(hero);
        await _context.SaveChangesAsync();
        
        return Ok(await _context.SuperHeroes.ToListAsync());
    }

    [HttpPut]
    public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
    {
        var dbHero = await _context.SuperHeroes.FindAsync(request.Id);
        
        if (dbHero == null)
        {
            return BadRequest("Heroi não encontrado");
        }

        dbHero.Name = request.Name;
        dbHero.FirstName = request.FirstName;
        dbHero.LastName = request.LastName;
        dbHero.Place = request.Place;

        await _context.SaveChangesAsync();
        
        return Ok(await _context.SuperHeroes.ToListAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<SuperHero>>> Delete(int id)
    {
        var dbHero = await _context.SuperHeroes.FindAsync(id);
        
        if (dbHero == null)
        {
            return BadRequest("Heroi não encontrado");
        }

        _context.SuperHeroes.Remove(dbHero);
        await _context.SaveChangesAsync();
        
        return Ok(await _context.SuperHeroes.ToListAsync());
    }
}

//post, get, put, delete
// c    r     u      d
// create read update delete