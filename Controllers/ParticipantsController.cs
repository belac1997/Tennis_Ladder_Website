using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TennisLadder.Data;
using TennisLadder.Models;
using System.Text.Encodings.Web;



namespace TennisLadder.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly TennisLadderContext _context;

        public ParticipantsController(TennisLadderContext context)
        {
            _context = context;
        }

        //GET: Rules
        public IActionResult Rules()
        {
            return View();
        }

        //GET: Participants/Tie/5/5
        public async Task<IActionResult> Tie(int? id, int? id2)
        {
            if (id == null || _context.Participants == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }

            if (id2 == null || _context.Participants == null)
            {
                return NotFound();
            }
            var chall = await _context.Participants
                .FirstOrDefaultAsync(m => m.Id == id2);
            if (chall == null)
            {
                return NotFound();
            }
            var both = (participant, chall);


            return View(both);
        }



        //GET: Participants/Winner/5/5
        public async Task<IActionResult> Winner(int? id, int? id2)
        {
            if (id == null || _context.Participants == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }

            if (id2 == null || _context.Participants == null)
            {
                return NotFound();
            }
            var chall = await _context.Participants
                .FirstOrDefaultAsync(m => m.Id == id2);
            if (chall == null)
            {
                return NotFound();
            }
            var both = (participant, chall);


            return View(both);
        }

        //GET: Participants/Challenges/5/5
        public async Task<IActionResult> Challenge(int? id, int? id2)
        {
            if (id == null || _context.Participants == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }

            if (id2 == null || _context.Participants == null)
            {
                return NotFound();
            }
            var chall = await _context.Participants
                .FirstOrDefaultAsync(m => m.Id == id2);
            if (chall == null)
            {
                return NotFound();
            }
            var both = (participant, chall);


            return View(both);
        }

        // POST: Participants/Tie/5/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Tie")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TieConfirmation(int id, int id2)
        {

            var participant = await _context.Participants.FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }

            var chall = await _context.Participants.FirstOrDefaultAsync(m => m.Id == id2);
            if (chall == null)
            {
                return NotFound();
            }

            chall.Availability = 0;
            participant.Availability = 0;
            chall.MatchPending = false;
            participant.MatchPending = false;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chall);
                    _context.Update(participant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipantExists(chall.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(participant);
        }

        // POST: Participants/Winner/5/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Winner")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> WinnerConfirmation(int id, int id2)
        {

            var participant = await _context.Participants.FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }

            var chall = await _context.Participants.FirstOrDefaultAsync(m => m.Id == id2);
            if (chall == null)
            {
                return NotFound();
            }
            
            ++chall.Wins;
            ++participant.Loses;
            chall.Availability = 0;
            participant.Availability = 0;
            chall.MatchPending = false;
            participant.MatchPending = false;


            if (participant.Rank < chall.Rank)
            {
                (participant.Rank, chall.Rank) = (chall.Rank, participant.Rank);
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chall);
                    _context.Update(participant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipantExists(chall.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(participant);
        }

        // POST: Participants/Challenge/5/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Challenge(int id, int id2)
        {

            if (id == null || _context.Participants == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }

            if (id2 == null || _context.Participants == null)
            {
                return NotFound();
            }
            var chall = await _context.Participants
                .FirstOrDefaultAsync(m => m.Id == id2);
            if (chall == null)
            {
                return NotFound();
            }
            chall.Availability = participant.Id;
            chall.MatchPending = true;
            participant.MatchPending = true;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chall);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipantExists(chall.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Ranks), "Participants", new { chall.Id});
            }
            return View(participant);
        }

        // GET: Participants
        public async Task<IActionResult> Index()
        {
              return _context.Participants != null ? 
                          View(await _context.Participants.OrderBy(m => m.Name).ToListAsync()) :
                          Problem("Entity set 'TennisLadderContext.Participant'  is null.");
        }
        // GET: Participants/Ranks/5
        public async Task<IActionResult> Ranks(int? id)
        {
            if (id == null || _context.Participants == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }

            var list = await _context.Participants.OrderBy(m => m.Rank).ToListAsync();


            var both = (list, participant);

            return View(both);
        }

        // GET: Participants/Challenges/5
        public async Task<IActionResult> Challenges(int? id)
        {
            if (id == null || _context.Participants == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }

            var list = await _context.Participants.OrderBy(m => m.Name).ToListAsync();


            var both = (list, participant);

            return View(both);
        }

        // GET: Participants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Participants == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // GET: Participants/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Participants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Rank,Wins,Loses,Availability,MatchPending")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(participant);
        }

        // GET: Participants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Participants == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }
            return View(participant);
        }

        // POST: Participants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Rank,Wins,Loses,Availability,MatchPending")] Participant participant)
        {
            if (id != participant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipantExists(participant.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(participant);
        }

        // GET: Participants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Participants == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // POST: Participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Participants == null)
            {
                return Problem("Entity set 'TennisLadderContext.Participant'  is null.");
            }
            var participant = await _context.Participants.FindAsync(id);
            if (participant != null)
            {
                _context.Participants.Remove(participant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipantExists(int id)
        {
          return (_context.Participants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
