//
//  IMOBFPayComponent.h
//  MOBPaySDK
//
//  Created by youzu_Max on 2017/9/15.
//  Copyright © 2017年 youzu. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <MOBFoundation/IMOBFServiceComponent.h>

@protocol MOBPayObserverDelegate;
@protocol IMPSPaymentTransaction;
@protocol IMPSCharge;

///**
// 支付回调协议
// */
//@protocol MOBPayObserverDelegate <NSObject>
//
///**
// 支付状态改变回调
//
// @param transaction 本次支付模型
// @param status 支付状态
// */
//- (void)paymentTransaction:(id<IMPSPaymentTransaction>)transaction statusDidChange:(NSInteger)status;
//
//@end

@protocol IMOBFPayComponent <IMOBFServiceComponent>

/**
 设置观察者，监听支付状态改变与回调
 
 @param observer 回调代理
 */
+ (void)addObserver:(id<MOBPayObserverDelegate>)observer;

/**
 支付接口
 
 @param charge 支付信息模型
 */
+ (void)payWithCharge:(id<IMPSCharge>)charge;

/**
 使用ticketId进行支付
 
 @param ticketId 支付标示
 */
+ (void)payWithTicketId:(NSString *)ticketId;

/**
 版本号
 
 @return 版本信息
 */
+ (NSString *)version;

/**
 日志打印
 
 @param enabled YES:开启日志 NO:关闭日志
 */
+ (void)setDebugMode:(BOOL)enabled;

@end


@protocol IMPSCharge


#pragma mark - 必须参数

/**
 订单Id
 */
@property (nonatomic, copy) NSString *orderId;

/**
 金额(单位：分)
 */
@property (nonatomic, assign) NSInteger amount;

/**
 标题
 */
@property (nonatomic, copy) NSString *subject;

/**
 支付通道
 */
@property (nonatomic, assign) NSInteger channel;


#pragma mark - 可选参数

/**
 商户用户Id
 */
@property (nonatomic, copy) NSString *appUserId;

/**
 商户用户昵称
 */
@property (nonatomic, copy) NSString *appUserNickname;

/**
 对一笔交易的具体描述信息。如果是多种商品，请将商品描述字符串累加传给body
 */
@property (nonatomic, copy) NSString *body;

/**
 订单附加说明，最多 255 个 Unicode 字符 (description)
 */
@property (nonatomic, copy) NSString *desc;

/**
 JSON格式的字符串，每一个对象的 metadata 最多可以拥有 10 个键值对，数据总长度在 1000 个 Unicode 字符以内。
 */
@property (nonatomic, copy) NSString *metadata;

@end


@protocol IMPSPaymentTransaction

/**
 支付渠道
 */
@property (nonatomic, assign) NSInteger channel;

/**
 支付id,用于支付结果查询
 */
@property (nonatomic, copy) NSString *ticketId;

/**
 错误信息
 */
@property (nonatomic, strong) NSError *error;

@end

