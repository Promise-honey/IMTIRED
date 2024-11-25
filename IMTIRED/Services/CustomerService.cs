using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IMTIRED.Models;

namespace IMTIRED.Services
{
    public class CustomerService
    {
        private readonly TlS2302374webContext _context;

        public CustomerService(TlS2302374webContext context)
        {
            _context = context;
        }

        // Existing methods remain as they are
        public async Task<Customer?> GetCustomerFromIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer?> LogIn(Customer customer)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Username == customer.Username && c.Password == customer.Password);
        }

        public async Task ChangePassword(int customerId, string hashedOldPassword, string hashedNewPassword)
        {
            Customer? customer = await _context.Customers.SingleOrDefaultAsync(c => c.CustomerId == customerId && c.Password == hashedOldPassword);
            if (customer != null)
            {
                customer.Password = hashedNewPassword;
                await _context.SaveChangesAsync();
            }
        }

        // New method to check if a username already exists
        public async Task<bool> CheckUsernameExistsAsync(string username)
        {
            // Query the database to see if the username exists
            return await _context.Customers.AnyAsync(c => c.Username == username);
        }

        // RegisterCustomer method to hash the password and add the customer to the database
        public async Task RegisterCustomer(Customer newCustomer, string confirmPassword, string errorMessage)
        {
            errorMessage = string.Empty; // Reset error message

            // Check if passwords match
            if (newCustomer.Password != confirmPassword)
            {
                errorMessage = "Passwords do not match";
                return;
            }

            // Check if username is already taken
            bool usernameTaken = await CheckUsernameExistsAsync(newCustomer.Username);

            if (usernameTaken)
            {
                errorMessage = "Username is already taken";
            }
            else
            {
                // Use the PasswordHasher to hash the password
                var passwordHasher = new PasswordHasher<Customer>();
                newCustomer.Password = passwordHasher.HashPassword(newCustomer, newCustomer.Password);

                // Add customer if validation passes
                await AddCustomerAsync(newCustomer);

                // Clear the form after successful registration
                newCustomer = new Customer();
                confirmPassword = string.Empty;

                // Redirect to login page or another page after successful registration
                // NavigationManager.NavigateTo("/log_in");  // This will be handled in the UI page
            }
        }
    }
}
