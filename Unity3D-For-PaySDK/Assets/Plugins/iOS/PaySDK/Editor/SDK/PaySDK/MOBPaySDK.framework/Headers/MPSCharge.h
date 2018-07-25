//
//  MPSCharge.h
//  MOBPaySDK
//
//  Created by youzu_Max on 2017/8/30.
//  Copyright © 2017年 youzu. All rights reserved.
//

#import <MOBFoundation/MOBFDataModel.h>
#import "MPSTypeDefines.h"

@interface MPSCharge : MOBFDataModel

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
@property (nonatomic, assign) MPSChannel channel;


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
