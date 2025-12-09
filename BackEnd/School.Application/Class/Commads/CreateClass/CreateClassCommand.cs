
using MediatR;

public class CreateClassCommand : IRequest<int>
{
    public string Name { get; set; }
    public string TeacherName { get; set; }
}

