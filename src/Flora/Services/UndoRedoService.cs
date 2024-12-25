using System;
using System.Collections.Generic;

namespace Flora.Services
{
    public class UndoRedoService
    {
        private Stack<UndoRedoAction> _undoStack = new Stack<UndoRedoAction>();
        private Stack<UndoRedoAction> _redoStack = new Stack<UndoRedoAction>();

        public void AddAction(UndoRedoAction action)
        {
            _undoStack.Push(action);
            _redoStack.Clear(); // Clear redo stack when new action is performed
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                var action = _undoStack.Pop();
                action.Undo();
                _redoStack.Push(action);
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                var action = _redoStack.Pop();
                action.Redo();
                _undoStack.Push(action);
            }
        }

        public bool CanUndo() => _undoStack.Count > 0;
        public bool CanRedo() => _redoStack.Count > 0;
    }

    public class UndoRedoAction
    {
        public Action Undo { get; }
        public Action Redo { get; }

        public UndoRedoAction(Action undo, Action redo)
        {
            Undo = undo;
            Redo = redo;
        }
    }
}
