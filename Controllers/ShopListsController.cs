﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConstantinCristinaLab11.Data;
using ConstantinCristinaLab11.Models;

namespace ConstantinCristinaLab11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopListsController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public ShopListsController(WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/ShopLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopList>>> GetShopList()
        {
            return await _context.ShopList.ToListAsync();
        }

        // GET: api/ShopLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopList>> GetShopList(int id)
        {
            var shopList = await _context.ShopList.FindAsync(id);

            if (shopList == null)
            {
                return NotFound();
            }

            return shopList;
        }

        // PUT: api/ShopLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShopList(int id, ShopList shopList)
        {
            if (id != shopList.ID)
            {
                return BadRequest();
            }

            _context.Entry(shopList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShopListExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ShopLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShopList>> PostShopList(ShopList shopList)
        {
            _context.ShopList.Add(shopList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShopList", new { id = shopList.ID }, shopList);
        }

        // DELETE: api/ShopLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopList(int id)
        {
            var shopList = await _context.ShopList.FindAsync(id);
            if (shopList == null)
            {
                return NotFound();
            }

            _context.ShopList.Remove(shopList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShopListExists(int id)
        {
            return _context.ShopList.Any(e => e.ID == id);
        }
    }
}
