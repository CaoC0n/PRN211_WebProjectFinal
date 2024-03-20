using System;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Numerics;

namespace BusinessLogic
{
    public class UserBusinessLogic
    {
        private TravelReviewContext userRepository;

        public UserBusinessLogic()
        {
            userRepository = new TravelReviewContext();
        }

        public void UpdateUser(int userId, string firstname, string lastname, string email, string phone, int gender)
        {
            var existingUser = userRepository.Users.FirstOrDefault(u => u.UserId == userId);

            if (!string.IsNullOrWhiteSpace(email) && !IsValidEmail(email))
            {
                throw new ArgumentException("Invalid email format.");
            }

            if (!string.IsNullOrWhiteSpace(phone) && !IsValidPhoneNumber(phone))
            {
                throw new ArgumentException("Invalid phone number format.");
            }

            existingUser.Gender = gender;


            if (!string.IsNullOrWhiteSpace(firstname))
            {
                existingUser.FirstName = firstname;
            }

            if (!string.IsNullOrWhiteSpace(lastname))
            {
                existingUser.LastName = lastname;
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                existingUser.Email = email;
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                existingUser.PhoneNumber = phone;
            }

            userRepository.SaveChanges();
        }

        public void CreateUser(string firstname, string lastname, string username, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Username and password are required.");
            }

            if (!IsValidEmail(email))
            {
                throw new ArgumentException("Invalid email format.");
            }

            var user = new User
            {
                FirstName = firstname,
                LastName = lastname,
                Username = username,
                Email = email,
                Password = password,
                Status = 0,
                Role = 1
            };

            userRepository.Users.Add(user);
            userRepository.SaveChanges();
        }

        public void changePassword(int userId, string oldPassword, string newPassword)
        {
            var user = userRepository.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                throw new ArgumentException("User not found!");
            }

            if (!user.Password.Equals(oldPassword)) 
            {
                throw new ArgumentException("Current password is not correct!");
            }

            user.Password = newPassword; 
            userRepository.SaveChanges(); 
        }

        private bool IsValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);
        }

        public void createReview(int userId, int locationId, string description)
        {
            var user = userRepository.Users.FirstOrDefault(u => u.UserId == userId);
            var location = userRepository.Addresses.FirstOrDefault(a => a.LocationId == locationId);

            if (user == null && location == null)
            {
                throw new ArgumentException("Not found!");
            }

            var review = new Review
            {
                UserId = userId,
                LocationId = locationId,
                Description = description,
                Date = DateTime.Now
            };
            userRepository.Reviews.Add(review);
            userRepository.SaveChanges();
        }
    }
}
