using Business.Factories;
using Business.Interfaces;
using Business.Models.ContactPersons;
using Data.Entities;
using Data.Interfaces;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services;

public class ContactPersonService(IContactPersonRepository contactPersonRepository) : IContactPersonService
{
    private readonly IContactPersonRepository _contactPersonRepository = contactPersonRepository;

    public async Task<ContactPerson?> CreateAsync(ContactPersonRegistrationForm contactPersonRegistrationForm)
    {
        if (contactPersonRegistrationForm == null)
            return null!;

        await _contactPersonRepository.BeginTransactionAsync();

        try
        {
            var contactPersonEntity = ContactPersonFactory.Create(contactPersonRegistrationForm);
            var createContactPerson = await _contactPersonRepository.CreateAsync(contactPersonEntity);
            await _contactPersonRepository.CommitTransactionAsync();
            return createContactPerson != null ? ContactPersonFactory.Create(createContactPerson) : null!;
        }
        catch (Exception ex)
        {
            await _contactPersonRepository.RollbackTransactionAsync();
            Debug.WriteLine($"Error creating ContactPerson entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<IEnumerable<ContactPerson>> GetAllAsync()
    {
        try
        {
            var allContactPersons = await _contactPersonRepository.GetAllAsync();
            return allContactPersons.Select(ContactPersonFactory.Create).ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting all ContactPerson entities : {ex.Message}");
            return null!;
        }
    }

    public async Task<ContactPerson?> GetAsync(int id)
    {
        try
        {
            var getContactPersonWithId = await _contactPersonRepository.GetAsync(c => c.Id == id);
            var result = getContactPersonWithId != null ? ContactPersonFactory.Create(getContactPersonWithId) : null;
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error getting ContactPerson entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<ContactPerson?> UpdateAsync(ContactPersonUpdateForm contactPersonUpdateForm)
    {
        if (contactPersonUpdateForm == null)
            return null!;

        try
        {
            var findUpdateContactPerson = await _contactPersonRepository.GetAsync(c => c.Id == contactPersonUpdateForm.Id);
            if (findUpdateContactPerson == null)
                return null!;


            ContactPersonFactory.Update(findUpdateContactPerson,contactPersonUpdateForm);
            var updateContactPerson = await _contactPersonRepository.UpdateAsync(c => c.Id == findUpdateContactPerson.Id, findUpdateContactPerson);
            return updateContactPerson != null ? ContactPersonFactory.Create(updateContactPerson) : null!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error updating ContactPerson entity : {ex.Message}");
            return null!;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var existContactPerson = await _contactPersonRepository.GetAsync(c => c.Id == id) ?? throw new Exception($"ContactPerson with id {id} does not exist");

            var deleteContactPerson = await _contactPersonRepository.DeleteAsync(c => c.Id == id);
            if (!deleteContactPerson)
                throw new Exception($"Error deleting ContactPerson with id {id}");

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error deleting ContactPerson entity : {ex.Message}");
            return false;
        }
    }
}
