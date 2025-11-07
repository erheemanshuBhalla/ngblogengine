using Code.Domain.Entities;
using Code.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task RegisterUserAsync(string name, string email)
        {
            var existing = await _unitOfWork.Users.GetByEmailAsync(email);
            if (existing != null)
                throw new Exception("User already exists.");

            var user = new Usermodel { Username = name, EmailAddress = email };
            await _unitOfWork.Users.AddAsync(user);

            _unitOfWork.Commit();
        }
    }
}
