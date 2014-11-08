﻿using UnityEngine;
using System.Collections;

public class PlayerController : BaseCharacterController {

	// === 外部パラメータ（インスペクタ表示） =====================
						 public float 	initHpMax = 20.0f;
	[Range(0.1f,100.0f)] public float 	initSpeed = 12.0f;

	// === 外部パラメータ ======================================
	// アニメーションのハッシュ名
	public readonly static int ANISTS_Idle 	 		= Animator.StringToHash("Base Layer.Player_Idle");
	public readonly static int ANISTS_Walk 	 		= Animator.StringToHash("Base Layer.Player_Walk");
	public readonly static int ANISTS_Run 	 	 	= Animator.StringToHash("Base Layer.Player_Run");
	public readonly static int ANISTS_Jump 	 		= Animator.StringToHash("Base Layer.Player_Jump");
	public readonly static int ANISTS_ATTACK_A 		= Animator.StringToHash("Base Layer.Player_ATK_A");
	public readonly static int ANISTS_ATTACK_B 		= Animator.StringToHash("Base Layer.Player_ATK_B");
	public readonly static int ANISTS_ATTACK_C	 	= Animator.StringToHash("Base Layer.Player_ATK_C");
	public readonly static int ANISTS_ATTACKJUMP_A  = Animator.StringToHash("Base Layer.Player_ATKJUMP_A");
	public readonly static int ANISTS_ATTACKJUMP_B  = Animator.StringToHash("Base Layer.Player_ATKJUMP_B");

	// === 内部パラメータ ======================================
	int 			jumpCount			= 0;
	bool			breakEnabled		= true;
	float 			groundFriction		= 0.0f;


	// === コード（Monobehaviour基本機能の実装） ================
	protected override void Awake () {
		base.Awake ();

		// パラメータ初期化
		speed = initSpeed;
		SetHP(initHpMax,initHpMax);
	}
	
	protected override void FixedUpdateCharacter () {
		// 現在のステートを取得
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

		// 着地チェック
		if (jumped) {
			if ((grounded && !groundedPrev) || 
				(grounded && Time.fixedTime > jumpStartTime + 1.0f)) {
				animator.SetTrigger ("Idle");
				jumped 	  = false;
				jumpCount = 0;
			}
		} else {
			jumpCount = 0;
		}

		// 攻撃中か？
		if (stateInfo.nameHash == ANISTS_ATTACK_A || 
		    stateInfo.nameHash == ANISTS_ATTACK_B || 
		    stateInfo.nameHash == ANISTS_ATTACK_C || 
		    stateInfo.nameHash == ANISTS_ATTACKJUMP_A || 
		    stateInfo.nameHash == ANISTS_ATTACKJUMP_B) {
			// 移動停止
			speedVx = 0;
		}

		// キャラの方向
		transform.localScale = new Vector3 (basScaleX * dir, transform.localScale.y, transform.localScale.z);

		// ジャンプ中の横移動減速
		if (jumped && !grounded && groundCheck_OnMoveObject == null) {
			if (breakEnabled) {
				breakEnabled = false;
				speedVx *= 0.9f;
			}
		}

		// 移動停止（減速）処理
		if (breakEnabled) {
			speedVx *= groundFriction;
		}

		// カメラ
		Camera.main.transform.position = transform.position + Vector3.back;
	}


	// === コード（基本アクション） =============================
	public override void ActionMove(float n) {
		if (!activeSts) {
			return;
		}

		// 初期化
		float dirOld = dir;
		breakEnabled = false;

		// アニメーション指定
		float moveSpeed = Mathf.Clamp(Mathf.Abs (n),-1.0f,+1.0f);
		animator.SetFloat("MovSpeed",moveSpeed);

		// 移動チェック
		if (n != 0.0f) {
			// 移動
			dir 	  = Mathf.Sign(n);
			moveSpeed = (moveSpeed < 0.5f) ? (moveSpeed * (1.0f / 0.5f)) : 1.0f;
			speedVx   = initSpeed * moveSpeed * dir;
		} else {
			// 移動停止
			breakEnabled = true;
		}

		// その場振り向きチェック
		if (dirOld != dir) {
			breakEnabled = true;
		}
	}

	public void ActionJump() {
		switch(jumpCount) {
		case 0 :
			if (grounded) {
				animator.SetTrigger ("Jump");
				rigidbody2D.velocity = Vector2.up * 30.0f;
				jumpStartTime = Time.fixedTime;
				jumped = true;
				jumpCount ++;
			}
			break;
		case 1 :
			if (!grounded) {
				animator.Play("Player_Jump",0,0.0f);
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,20.0f);
				jumped = true;
				jumpCount ++;
			}
			break;
		}
	}

	public void ActionAttack() {
		AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
		if (stateInfo.nameHash != ANISTS_ATTACK_A) {
			animator.SetTrigger ("Attack_A");
		} else {
			animator.SetTrigger ("Attack_B");
		}
	}

}


