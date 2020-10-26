using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    [Owned]
    public class Tbl_RefreshToken
    {
        [Key]
        public int Id { get; set; }
        public Tbl_Users User { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public int UserId { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
    }
}