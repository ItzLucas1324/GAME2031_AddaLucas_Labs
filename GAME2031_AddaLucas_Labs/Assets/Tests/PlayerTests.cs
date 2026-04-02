using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerTests
{
    private const string SceneName = "GameScene";

    [UnityTest]
    public IEnumerator TestPlayerSetup()
    {
        SceneManager.LoadScene(SceneName);

        yield return null;

        PlayerController playerController = GameObject.FindFirstObjectByType<PlayerController>();


        // PlayerController != null
        Assert.IsNotNull(playerController, "PlayerController is null");
        GameObject playerGO = playerController.gameObject;

        // Player Rigidbody 2D
        Rigidbody2D rigidBody2d = playerGO.GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rigidBody2d, "Player has no RigidBody2D");

        // Collider
        Collider2D collider2D = playerGO.GetComponent<Collider2D>();
        Assert.IsNotNull(collider2D, "Player has no Collider2D");

        // rb2d is dynamic
        Assert.AreEqual(RigidbodyType2D.Dynamic, rigidBody2d.bodyType, "RigidBody2D is not dynamic");

        // gravity == 0
        Assert.AreEqual(0, rigidBody2d.gravityScale, "Gravity Scale is not 0");
    }
}
