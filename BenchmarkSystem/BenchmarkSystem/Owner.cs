using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BenchmarkSystemNs {
  /// <summary>
  /// Owner describes the owner of a Job.
  /// </summary>
  public class Owner {
    public Owner(string Name) {
      this.Name = Name;
    }
    public Owner() { }
    [Key]
    public int id { get; set; }
    public string Name {
      get;
      set;
    }
  }
}
