using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public interface ICommand
    {
        void Execute();
    }

    public class MoveLeftCommand : ICommand
    {
        private Character _character;
        public MoveLeftCommand(Character character)
        {
            _character = character;
        }
        public void Execute()
        {
            _character.MoveLeft();
        }
    }
    public class MoveRightCommand : ICommand
    {
        private Character _character;
        public MoveRightCommand(Character character)
        {
            _character = character;
        }
        public void Execute()
        {
            _character.MoveRight();
        }
    }
    public class Character
    {
        public void MoveLeft()
        {
        // code to move the character left
        }
        public void MoveRight()
        {
        // code to move the character right
        }   
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
        }
    }
