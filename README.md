# Uzbekistan PINFL Validation for FluentValidation

A lightweight validation library for verifying Uzbekistan PINFL (Personal Identification Number of an Individual) values using FluentValidation.

---

## 📌 About

This library provides validation logic to check whether a PINFL belonging to a citizen of Uzbekistan is valid or not.

It ensures that the given PINFL:
- Follows the correct format
- Matches expected structural rules
- Is not malformed or invalid

This helps developers prevent incorrect user data and enforce consistent validation across applications.

---

## 🚀 Features

- ✔ PINFL format validation
- ✔ Easy integration with FluentValidation
- ✔ Lightweight and fast
- ✔ Clean and reusable validation rules

---

## 📦 Installation

Install via NuGet:

```bash
dotnet add package Uzbekistan.Pinfl.FluentValidation
```

## 🛠 Usage
Example Model
```csharp
public class Person
{
    public string Pinfl { get; set; }
}
```
Validator

```csharp
using FluentValidation;
using Uzbekistan.Pinfl.FluentValidation.Extensions;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(x => x.Pinfl)
            .NotEmpty()
            .Pinfl();
    }
}
```

## ✅ Example
```csharp
var person = new Person { Pinfl = "12345678901234" };
var validator = new PersonValidator();

var result = validator.Validate(person);

if (!result.IsValid)
{
    Console.WriteLine("PINFL is invalid");
}
```


## 🤝 Contributing

* Contributions are welcome!
* Fork the repository
* Create a new branch
* Submit a pull request

## 📄 License

This project is licensed under the MIT License.

## ⭐ Support

If you find this project useful, please consider giving it a star ⭐

---

If you want, I can next:
- add **real PINFL validation implementation**
- generate **unit tests**
- or improve README with badges (NuGet, build status, etc.)