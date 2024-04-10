﻿using CRM_DOBRO.Data;
using CRM_DOBRO.DTOs;
using CRM_DOBRO.Entities;
using CRM_DOBRO.Enums;
using Microsoft.EntityFrameworkCore;
namespace CRM_DOBRO.Services
{
    public class ContactService(CRMDBContext context)
    {
        private readonly CRMDBContext _context = context;


        public async Task<List<ContactGetDTO>> GetContactsAsync()
        {
            List<Contact> contacts = await _context.Contacts.Include(c => c.Marketing).ToListAsync();
            List<ContactGetDTO> contactsDTO = [];

            foreach (var contact in contacts)
            {
                ContactGetDTO contactDTO = new ()
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    Surname = contact.Surname,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    PhoneNumber = contact.PhoneNumber,
                    Status = contact.Status,
                    MarketingId = contact.MarketingId,
                    MarketingFullName = contact.Marketing?.FullName ?? "null",
                    DateOfLastChanges = contact.DateOfLastChanges,
                };
                contactsDTO.Add(contactDTO);
            }
            return contactsDTO;
        }

        public async Task<List<ContactGetDTO>> GetContactLeadsAsync()
        {
            var leads = await _context.Contacts
                .Include(c => c.Marketing)
                .Where(c => c.Status == ContactStatus.Lead)
                .ToListAsync();
            List<ContactGetDTO> contactsDTO = [];

            foreach (var leadContact in leads)
            {
                ContactGetDTO contactDTO = new()
                {
                    Id = leadContact.Id,
                    Name = leadContact.Name,
                    Surname = leadContact.Surname,
                    LastName = leadContact.LastName,
                    Email = leadContact.Email,
                    PhoneNumber = leadContact.PhoneNumber,
                    Status = leadContact.Status,
                    MarketingId = leadContact.MarketingId,
                    MarketingFullName = leadContact.Marketing?.FullName ?? "null",
                    DateOfLastChanges = leadContact.DateOfLastChanges,
                };
                contactsDTO.Add(contactDTO);
            }
            return contactsDTO;
        }

        public async Task CreateContactAsync(ContactSetDTO contact, int marketingId)
        {
            Contact newContact = new()
            {
                Name = contact.Name,
                Surname= contact.Surname,
                LastName = contact.LastName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Status= contact.Status,
                MarketingId = marketingId,
                DateOfLastChanges = DateTime.Now,
            };
            _context.Add(newContact);
            await _context.SaveChangesAsync();
        }

        public async Task ContactChangeAsync(ContactSetDTO contact, int contactId)
        {
            var contactToChange = await _context.Contacts.FirstAsync(c => c.Id == contactId);

            contactToChange.Name = contact.Name;
            contactToChange.Surname = contact.Surname;
            contactToChange.LastName = contact.LastName;
            contactToChange.Email = contact.Email;
            contactToChange.PhoneNumber = contact.PhoneNumber;
            contactToChange.Status = contact.Status;
            contactToChange.DateOfLastChanges = DateTime.Now;

            _context.Update(contactToChange);
            await _context.SaveChangesAsync();
        }


        public async Task ContactChangeStatusAsync(ContactStatus status, int contactId)
        {
            var contact = await _context.Contacts.FirstAsync(c => c.Id == contactId);
            contact.Status = status;
            contact.DateOfLastChanges = DateTime.Now;
            _context.Update(contact);
            await _context.SaveChangesAsync();
        }
    }
}
