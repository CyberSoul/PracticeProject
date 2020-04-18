using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //Needed for Enumerable.Reverse

public class CommandManager : SingletonTemplate<CommandManager>
{
    private List<ICommand> m_commands = new List<ICommand>();
    [SerializeField] float m_delayTime = 1;

    public void AddCommand(ICommand a_command)
    {
        m_commands.Add(a_command);
    }

    public void Play()
    {
        StartCoroutine(PlayCommandRoutine());
    }

    IEnumerator PlayCommandRoutine()
    {
        foreach(var command in m_commands)
        {
            command.Execute();
            yield return new WaitForSeconds(m_delayTime);
        }
    }

    public void Rewind()
    {
        StartCoroutine(RewindCommandRoutine());
    }

    IEnumerator RewindCommandRoutine()
    {
        for (int i = m_commands.Count - 1; i >= 0; --i)
        {
            m_commands[i].Undue();
            yield return new WaitForSeconds(m_delayTime);
        }

        //Equal to upper for
        /*foreach (var command in Enumerable.Reverse(m_commands))
        {
            command.Undue();
            yield return new WaitForSeconds(1);
        }*/
    }

    public void Reset()
    {
        m_commands.Clear();
    }

}
